using Microsoft.AspNetCore.Mvc;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Songs;

namespace MusicTw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongService _songService;

    public SongsController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SongListItemDto>>> Get(CancellationToken cancellationToken)
    {
        var response = await _songService.GetCatalogAsync(cancellationToken);
        return Ok(response);
    }
}
