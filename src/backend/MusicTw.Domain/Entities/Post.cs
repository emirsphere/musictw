namespace MusicTw.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SongId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; } = null!;
    public Song Song { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<PostLike> Likes { get; set; } = new List<PostLike>();
}
