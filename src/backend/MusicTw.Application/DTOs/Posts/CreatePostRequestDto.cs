using System.ComponentModel.DataAnnotations;

namespace MusicTw.Application.DTOs.Posts;

public class CreatePostRequestDto
{
    [Required]
    public Guid SongId { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string Content { get; set; } = null!;
}
