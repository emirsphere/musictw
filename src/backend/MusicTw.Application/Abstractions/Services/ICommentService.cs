using MusicTw.Application.DTOs.Comments;

namespace MusicTw.Application.Abstractions.Services;

public interface ICommentService
{
    Task<CommentDto> CreateAsync(Guid postId, CreateCommentRequestDto request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CommentDto>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);
}
