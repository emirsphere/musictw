using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Posts;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Features.Posts;

public class PostService : IPostService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public PostService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<PostDto> CreateAsync(CreatePostRequestDto request, CancellationToken cancellationToken = default)
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var song = await _dbContext.Songs
            .FirstOrDefaultAsync(x => x.Id == request.SongId, cancellationToken);

        if (song is null)
        {
            throw new InvalidOperationException("Selected song was not found.");
        }

        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId.Value, cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Current user was not found.");
        }

        var post = new Post
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            SongId = song.Id,
            Content = request.Content.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PostDto
        {
            PostId = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
            UserId = user.Id,
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            SongId = song.Id,
            SongTitle = song.Title,
            SongArtist = song.Artist,
            SongCoverImageUrl = song.CoverImageUrl,
            SongDuration = song.Duration,
            CommentCount = 0,
            LikeCount = 0,
            IsLikedByCurrentUser = false
        };
    }

    public async Task<PostDto> GetByIdAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        var currentUserId = _currentUserService.UserId;

        var post = await _dbContext.Posts
            .AsNoTracking()
            .Where(x => x.Id == postId)
            .Select(x => new PostDto
            {
                PostId = x.Id,
                Content = x.Content,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                UserId = x.UserId,
                UserName = x.User.UserName,
                AvatarUrl = x.User.AvatarUrl,
                SongId = x.SongId,
                SongTitle = x.Song.Title,
                SongArtist = x.Song.Artist,
                SongCoverImageUrl = x.Song.CoverImageUrl,
                SongDuration = x.Song.Duration,
                CommentCount = x.Comments.Count,
                LikeCount = x.Likes.Count,
                IsLikedByCurrentUser = currentUserId.HasValue && x.Likes.Any(like => like.UserId == currentUserId.Value)
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (post is null)
        {
            throw new InvalidOperationException("Post was not found.");
        }

        return post;
    }
}
