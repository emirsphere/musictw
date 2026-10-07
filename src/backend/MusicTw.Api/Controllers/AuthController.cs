using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Auth;

namespace MusicTw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ICurrentUserService _currentUserService;

    public AuthController(IAuthService authService, ICurrentUserService currentUserService)
    {
        _authService = authService;
        _currentUserService = currentUserService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(
        [FromBody] RegisterRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _authService.RegisterAsync(request, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(
        [FromBody] LoginRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _authService.LoginAsync(request, cancellationToken);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("me")]
    [Authorize]
    public ActionResult<CurrentUserDto> Me()
    {
        if (!_currentUserService.IsAuthenticated || _currentUserService.UserId is null)
        {
            return Unauthorized();
        }

        return Ok(new CurrentUserDto
        {
            UserId = _currentUserService.UserId.Value,
            UserName = _currentUserService.UserName ?? string.Empty,
            Email = _currentUserService.Email ?? string.Empty,
            IsAuthenticated = _currentUserService.IsAuthenticated
        });
    }
}
