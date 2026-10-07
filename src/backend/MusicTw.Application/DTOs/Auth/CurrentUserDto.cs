namespace MusicTw.Application.DTOs.Auth;

public class CurrentUserDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsAuthenticated { get; set; }
}
