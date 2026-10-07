using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Feed;
using MusicTw.Application.DTOs.Profiles;

namespace MusicTw.Application.Features.Profiles;

public class ProfileService : IProfileService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public ProfileService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<ProfileDto> GetMeAsync(CancellationToken cancellationToken = default)
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        return await BuildProfileAsync(_currentUserService.UserId.Value, includeEmail: true, cancellationToken);
    }

    public async Task<ProfileDto> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var includeEmail = _currentUserService.UserId == userId;
        return await BuildProfileAsync(userId, includeEmail, cancellationToken);
    }

    public async Task<IReadOnlyList<FeedItemDto>> GetPostsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var userExists = await _dbContext.Users.AnyAsync(x => x.Id == userId, cancellationToken);
        if (!userExists)
        {
            throw new InvalidOperationException("User was not found.");
        }

        var currentUserId = _currentUserService.UserId;

        return await _dbContext.Posts
            .AsNoTracking()
            .Where(x => x.UserId == userId)
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

    private async Task<ProfileDto> BuildProfileAsync(Guid userId, bool includeEmail, CancellationToken cancellationToken)
    {
        var profile = await _dbContext.Users
            .AsNoTracking()
            .Where(x => x.Id == userId)
            .Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email,
                x.Bio,
                x.AvatarUrl,
                FollowerCount = x.Followers.Count,
                FollowingCount = x.Following.Count,
                PostCount = x.Posts.Count
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (profile is null)
        {
            throw new InvalidOperationException("User was not found.");
        }

        var currentUserId = _currentUserService.UserId;
        var isCurrentUser = currentUserId == userId;
        var isFollowedByCurrentUser = false;

        if (currentUserId.HasValue && !isCurrentUser)
        {
            isFollowedByCurrentUser = await _dbContext.Follows
                .AsNoTracking()
                .AnyAsync(x => x.FollowerId == currentUserId.Value && x.FollowingId == userId, cancellationToken);
        }

        return new ProfileDto
        {
            UserId = profile.Id,
            UserName = profile.UserName,
            Email = includeEmail ? profile.Email : null,
            Bio = profile.Bio,
            AvatarUrl = profile.AvatarUrl,
            FollowerCount = profile.FollowerCount,
            FollowingCount = profile.FollowingCount,
            PostCount = profile.PostCount,
            IsCurrentUser = isCurrentUser,
            IsFollowedByCurrentUser = isFollowedByCurrentUser
        };
    }
}
