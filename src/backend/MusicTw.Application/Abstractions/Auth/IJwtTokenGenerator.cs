using MusicTw.Domain.Entities;

namespace MusicTw.Application.Abstractions.Auth;

public interface IJwtTokenGenerator
{
    (string Token, DateTime ExpiresAtUtc) Generate(User user);
}
