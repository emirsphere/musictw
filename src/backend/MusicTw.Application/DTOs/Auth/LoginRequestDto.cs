using System.ComponentModel.DataAnnotations;

namespace MusicTw.Application.DTOs.Auth;

public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = null!;
}
