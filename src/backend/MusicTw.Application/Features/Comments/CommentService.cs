using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Comments;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Features.Comments;

public class CommentService : ICommentService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public CommentService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<CommentDto> CreateAsync(Guid postId, CreateCommentRequestDto request, CancellationToken cancellationToken = default)
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var postExists = await _dbContext.Posts.AnyAsync(x => x.Id == postId, cancellationToken);
        if (!postExists)
        {
            throw new InvalidOperationException("Post was not found.");
        }

        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId.Value, cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Current user was not found.");
        }

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            PostId = postId,
            UserId = user.Id,
            Content = request.Content.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Map(comment, user);
    }

    public async Task<IReadOnlyList<CommentDto>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        var postExists = await _dbContext.Posts.AnyAsync(x => x.Id == postId, cancellationToken);
        if (!postExists)
        {
            throw new InvalidOperationException("Post was not found.");
        }

        return await _dbContext.Comments
            .AsNoTracking()
            .Where(x => x.PostId == postId)
            .OrderBy(x => x.CreatedAt)
            .Select(x => new CommentDto
            {
                CommentId = x.Id,
                PostId = x.PostId,
                UserId = x.UserId,
                UserName = x.User.UserName,
                AvatarUrl = x.User.AvatarUrl,
                Content = x.Content,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }

    private static CommentDto Map(Comment comment, User user)
    {
        return new CommentDto
        {
            CommentId = comment.Id,
            PostId = comment.PostId,
            UserId = comment.UserId,
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        };
    }
}
