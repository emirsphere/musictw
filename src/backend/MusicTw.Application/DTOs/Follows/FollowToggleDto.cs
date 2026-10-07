namespace MusicTw.Application.DTOs.Follows;

public class FollowToggleDto
{
    public Guid UserId { get; set; }
    public int FollowerCount { get; set; }
    public int FollowingCount { get; set; }
    public bool IsFollowedByCurrentUser { get; set; }
}
