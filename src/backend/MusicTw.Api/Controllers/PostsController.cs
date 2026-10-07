using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.DTOs.Comments;
using MusicTw.Application.DTOs.Likes;
using MusicTw.Application.DTOs.Posts;

namespace MusicTw.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly ICommentService _commentService;
    private readonly ILikeService _likeService;

    public PostsController(IPostService postService, ICommentService commentService, ILikeService likeService)
    {
        _postService = postService;
        _commentService = commentService;
        _likeService = likeService;
    }

    [HttpGet("{postId:guid}")]
    public async Task<ActionResult<PostDto>> GetById(Guid postId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _postService.GetByIdAsync(postId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PostDto>> Create(
        [FromBody] CreatePostRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _postService.CreateAsync(request, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("{postId:guid}/comments")]
    public async Task<ActionResult<IReadOnlyList<CommentDto>>> GetComments(
        Guid postId,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _commentService.GetByPostIdAsync(postId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost("{postId:guid}/comments")]
    [Authorize]
    public async Task<ActionResult<CommentDto>> CreateComment(
        Guid postId,
        [FromBody] CreateCommentRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _commentService.CreateAsync(postId, request, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("{postId:guid}/like")]
    [Authorize]
    public async Task<ActionResult<PostLikeToggleDto>> ToggleLike(
        Guid postId,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _likeService.ToggleAsync(postId, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
