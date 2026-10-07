using MusicTw.Application.DTOs.Likes;

namespace MusicTw.Application.Abstractions.Services;

public interface ILikeService
{
    Task<PostLikeToggleDto> ToggleAsync(Guid postId, CancellationToken cancellationToken = default);
}
