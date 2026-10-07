using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Feed;
using MusicTw.Application.DTOs.Follows;
using MusicTw.Application.DTOs.Profiles;

namespace MusicTw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IFollowService _followService;

    public ProfilesController(IProfileService profileService, IFollowService followService)
    {
        _profileService = profileService;
        _followService = followService;
    }

    [HttpGet("me")]
    public async Task<ActionResult<ProfileDto>> GetMe(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _profileService.GetMeAsync(cancellationToken);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<ProfileDto>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _profileService.GetByUserIdAsync(userId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{userId:guid}/posts")]
    public async Task<ActionResult<IReadOnlyList<FeedItemDto>>> GetPostsByUserId(
        Guid userId,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _profileService.GetPostsByUserIdAsync(userId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost("{userId:guid}/follow")]
    public async Task<ActionResult<FollowToggleDto>> ToggleFollow(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _followService.ToggleAsync(userId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
