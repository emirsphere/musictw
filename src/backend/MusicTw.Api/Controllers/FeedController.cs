using Microsoft.AspNetCore.Mvc;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Feed;

namespace MusicTw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedController : ControllerBase
{
    private readonly IFeedService _feedService;

    public FeedController(IFeedService feedService)
    {
        _feedService = feedService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<FeedItemDto>>> Get(CancellationToken cancellationToken)
    {
        var response = await _feedService.GetGlobalFeedAsync(cancellationToken);
        return Ok(response);
    }
}
