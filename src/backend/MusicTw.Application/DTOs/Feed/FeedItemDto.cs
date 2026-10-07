namespace MusicTw.Application.DTOs.Feed;

public class FeedItemDto
{
    public Guid PostId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public Guid SongId { get; set; }
    public string SongTitle { get; set; } = null!;
    public string SongArtist { get; set; } = null!;
    public string? SongCoverImageUrl { get; set; }
    public TimeSpan SongDuration { get; set; }
    public int CommentCount { get; set; }
    public int LikeCount { get; set; }
    public bool IsLikedByCurrentUser { get; set; }
}
