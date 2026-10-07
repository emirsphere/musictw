using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Feed;

namespace MusicTw.Application.Features.Feed;

public class FeedService : IFeedService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public FeedService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<IReadOnlyList<FeedItemDto>> GetGlobalFeedAsync(CancellationToken cancellationToken = default)
    {
        var currentUserId = _currentUserService.UserId;

        return await _dbContext.Posts
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new FeedItemDto
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
            .ToListAsync(cancellationToken);
    }
}
