namespace MusicTw.Domain.Entities;

public class Song
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Artist { get; set; } = null!;
    public string? Album { get; set; }
    public string? CoverImageUrl { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsSeeded { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
