using ArtHub.DTO.PostCommentDTO;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper, IPostService postService, ICommentService commentService)
        {
            _mapper = mapper;
            _postService = postService;
            _commentService = commentService;
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId)
        {
            var comments = await _commentService.GetCommentsByPostId(postId);
            if (comments == null)
                return NotFound();
            return Ok(comments);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateComment([FromBody] CreateComment creating)
        {
            if (creating.PostId <= 0)
            {
                return BadRequest();
            }
            var newComment = await _commentService.AddCommentAsync(creating);
            return CreatedAtAction(nameof(GetCommentById), new { commentId = newComment.CommentId }, newComment);
        }

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
                return NotFound();
            return Ok(comment);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
                return NotFound();
            await _commentService.DeleteCommentAsync(commentId);
            return NoContent();
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] UpdateComment updating)
        {
            if (commentId != updating.CommentId)
            {
                return BadRequest();
            }
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
                return NotFound();
            var result = await _commentService.UpdateCommentAsync(commentId, updating);
            return Ok(result);
        }
    }
}
