using MusicTw.Application.DTOs.Posts;

namespace MusicTw.Application.Abstractions.Services;

public interface IPostService
{
    Task<PostDto> CreateAsync(CreatePostRequestDto request, CancellationToken cancellationToken = default);
    Task<PostDto> GetByIdAsync(Guid postId, CancellationToken cancellationToken = default);
}
