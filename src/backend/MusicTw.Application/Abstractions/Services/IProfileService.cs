using MusicTw.Application.DTOs.Feed;
using MusicTw.Application.DTOs.Profiles;

namespace MusicTw.Application.Abstractions.Services;

public interface IProfileService
{
    Task<ProfileDto> GetMeAsync(CancellationToken cancellationToken = default);
    Task<ProfileDto> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<FeedItemDto>> GetPostsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}
