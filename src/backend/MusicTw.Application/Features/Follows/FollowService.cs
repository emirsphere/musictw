using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Follows;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Features.Follows;

public class FollowService : IFollowService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public FollowService(IAppDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
    }

    public async Task<FollowToggleDto> ToggleAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var currentUserId = _currentUserService.UserId.Value;

        if (currentUserId == userId)
        {
            throw new InvalidOperationException("You cannot follow yourself.");
        }

        var userExists = await _dbContext.Users.AnyAsync(x => x.Id == userId, cancellationToken);
        if (!userExists)
        {
            throw new InvalidOperationException("User was not found.");
        }

        var existingFollow = await _dbContext.Follows
            .FirstOrDefaultAsync(x => x.FollowerId == currentUserId && x.FollowingId == userId, cancellationToken);

        var isFollowedByCurrentUser = false;

        if (existingFollow is null)
        {
            _dbContext.Follows.Add(new Follow
            {
                FollowerId = currentUserId,
                FollowingId = userId,
                CreatedAt = DateTime.UtcNow
            });

            isFollowedByCurrentUser = true;
        }
        else
        {
            _dbContext.Follows.Remove(existingFollow);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        var followerCount = await _dbContext.Follows.CountAsync(x => x.FollowingId == userId, cancellationToken);
        var followingCount = await _dbContext.Follows.CountAsync(x => x.FollowerId == userId, cancellationToken);

        return new FollowToggleDto
        {
            UserId = userId,
            FollowerCount = followerCount,
            FollowingCount = followingCount,
            IsFollowedByCurrentUser = isFollowedByCurrentUser
        };
    }
}
