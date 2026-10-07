using MusicTw.Application.DTOs.Songs;

namespace MusicTw.Application.Abstractions.Services;

public interface ISongService
{
    Task<IReadOnlyList<SongListItemDto>> GetCatalogAsync(CancellationToken cancellationToken = default);
}
