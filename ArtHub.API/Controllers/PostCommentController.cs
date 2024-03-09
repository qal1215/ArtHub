using ArtHub.DAO.PostCommentDTO;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("post")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PostCommentController(IMapper mapper, IPostService postService, ICommentService commentService)
        {
            _mapper = mapper;
            _postService = postService;
            _commentService = commentService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePost creating)
        {
            var newPost = await _postService.AddPostAsync(creating);
            return CreatedAtAction(nameof(GetPostById), new { postId = newPost.PostId }, newPost);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById([FromRoute] int postId)
        {
            var posts = await _postService.GetPostAsync(postId);
            if (posts == null)
                return NotFound();
            return Ok(posts);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost([FromRoute] int postId)
        {
            var post = await _postService.GetPostAsync(postId);
            if (post == null)
                return NotFound();
            await _postService.DeletePostAsync(postId);
            return NoContent();
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int postId, [FromBody] UpdatePost updating)
        {
            if (postId != updating.PostId)
            {
                return BadRequest();
            }
            var post = await _postService.GetPostAsync(postId);
            if (post == null)
                return NotFound();
            var result = await _postService.UpdatePostAsync(postId, updating);
            return Ok(result);
        }

        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId)
        {
            var comments = await _commentService.GetCommentsByPostId(postId);
            if (comments == null)
                return NotFound();
            return Ok(comments);
        }

        [HttpPost("{postId}/comment")]
        public async Task<IActionResult> CreateComment([FromRoute] int postId, [FromBody] CreateComment creating)
        {
            if (postId != creating.PostId)
            {
                return BadRequest();
            }
            var newComment = await _commentService.AddCommentAsync(creating);
            return CreatedAtAction(nameof(GetCommentById), new { commentId = newComment.CommentId }, newComment);
        }

        [HttpGet("/comment/{commentId}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
                return NotFound();
            return Ok(comment);
        }

        [HttpDelete("/comment/{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if (comment == null)
                return NotFound();
            await _commentService.DeleteCommentAsync(commentId);
            return NoContent();
        }

        [HttpPut("/comment/{commentId}")]
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
