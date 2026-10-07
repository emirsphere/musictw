using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Likes;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Features.Likes;

public class LikeService : ILikeService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public LikeService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<PostLikeToggleDto> ToggleAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var userId = _currentUserService.UserId.Value;

        var postExists = await _dbContext.Posts.AnyAsync(x => x.Id == postId, cancellationToken);
        if (!postExists)
        {
            throw new InvalidOperationException("Post was not found.");
        }

        var existingLike = await _dbContext.PostLikes
            .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId, cancellationToken);

        var isLikedByCurrentUser = false;

        if (existingLike is null)
        {
            _dbContext.PostLikes.Add(new PostLike
            {
                PostId = postId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            });

            isLikedByCurrentUser = true;
        }
        else
        {
            _dbContext.PostLikes.Remove(existingLike);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        var likeCount = await _dbContext.PostLikes.CountAsync(x => x.PostId == postId, cancellationToken);

        return new PostLikeToggleDto
        {
            PostId = postId,
            LikeCount = likeCount,
            IsLikedByCurrentUser = isLikedByCurrentUser
        };
    }
}
