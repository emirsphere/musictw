using Microsoft.EntityFrameworkCore;
using MusicTw.Application.Abstractions.Auth;
using MusicTw.Application.Abstractions.Persistence;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Auth;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Features.Auth;

public class AuthService : IAuthService
{
    private readonly IAppDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        IAppDbContext dbContext,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
    {
        var normalizedUserName = request.UserName.Trim();
        var normalizedEmail = request.Email.Trim().ToLowerInvariant();

        var userNameExists = await _dbContext.Users
            .AnyAsync(x => x.UserName == normalizedUserName, cancellationToken);

        if (userNameExists)
        {
            throw new InvalidOperationException("Username is already taken.");
        }

        var emailExists = await _dbContext.Users
            .AnyAsync(x => x.Email == normalizedEmail, cancellationToken);

        if (emailExists)
        {
            throw new InvalidOperationException("Email is already in use.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = normalizedUserName,
            Email = normalizedEmail,
            PasswordHash = _passwordHasher.Hash(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var (token, expiresAtUtc) = _jwtTokenGenerator.Generate(user);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = request.Email.Trim().ToLowerInvariant();

        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == normalizedEmail, cancellationToken);

        if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var (token, expiresAtUtc) = _jwtTokenGenerator.Generate(user);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}
