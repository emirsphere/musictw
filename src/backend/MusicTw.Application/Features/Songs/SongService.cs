using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Songs;

namespace MusicTw.Application.Features.Songs;

public class SongService : ISongService
{
    private readonly IAppDbContext _dbContext;

    public SongService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<SongListItemDto>> GetCatalogAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Songs
            .AsNoTracking()
            .Where(x => x.IsSeeded)
            .OrderBy(x => x.Artist)
            .ThenBy(x => x.Title)
            .Select(x => new SongListItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Artist = x.Artist,
                Album = x.Album,
                CoverImageUrl = x.CoverImageUrl,
                Duration = x.Duration
            })
            .ToListAsync(cancellationToken);
    }
}
