namespace MusicTw.Application.DTOs.Profiles;

public class ProfileDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string? Email { get; set; }
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public int FollowerCount { get; set; }
    public int FollowingCount { get; set; }
    public int PostCount { get; set; }
    public bool IsCurrentUser { get; set; }
    public bool IsFollowedByCurrentUser { get; set; }
}
