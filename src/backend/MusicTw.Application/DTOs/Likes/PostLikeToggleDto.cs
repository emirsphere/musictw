namespace MusicTw.Application.DTOs.Likes;

public class PostLikeToggleDto
{
    public Guid PostId { get; set; }
    public int LikeCount { get; set; }
    public bool IsLikedByCurrentUser { get; set; }
}
