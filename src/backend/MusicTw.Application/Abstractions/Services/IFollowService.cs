using MusicTw.Application.DTOs.Follows;

namespace MusicTw.Application.Abstractions.Services;

public interface IFollowService
{
    Task<FollowToggleDto> ToggleAsync(Guid userId, CancellationToken cancellationToken = default);
}
