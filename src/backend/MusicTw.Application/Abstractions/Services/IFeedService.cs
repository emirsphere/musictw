using MusicTw.Application.DTOs.Feed;

namespace MusicTw.Application.Abstractions.Services;

public interface IFeedService
{
    Task<IReadOnlyList<FeedItemDto>> GetGlobalFeedAsync(CancellationToken cancellationToken = default);
}
