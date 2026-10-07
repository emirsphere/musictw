using System.ComponentModel.DataAnnotations;

namespace MusicTw.Application.DTOs.Comments;

public class CreateCommentRequestDto
{
    [Required]
    [StringLength(500, MinimumLength = 1)]
    public string Content { get; set; } = null!;
}
