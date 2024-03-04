using ArtHub.DAO.PostCommentDTO;
using ArtHub.Service;
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

        [HttpPost("post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePost creating)
        {
            var newPost = await _postService.AddPostAsync(creating);
            return CreatedAtAction(nameof(GetPostById), new { postId = newPost.PostId }, newPost);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetPostById([FromRoute] int postId)
        {
            var posts = await _postService.GetPostAsync(postId);
            if (posts == null)
                return NotFound();
            return Ok(posts);
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
    }
}
