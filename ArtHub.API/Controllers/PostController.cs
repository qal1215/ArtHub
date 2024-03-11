using ArtHub.DTO.ModelResult;
using ArtHub.DTO.PostCommentDTO;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper, IPostService postService, ICommentService commentService)
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

        [HttpGet("/post/user/{userId}")]
        public async Task<IActionResult> GetPostByUserId([FromRoute] int userId, [FromQuery] QueryPaging queryPaging)
        {
            var result = await _postService.GetPostByUserId(userId, queryPaging);

            if (result.TotalItems <= 0)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("/post/artwork/{artworkId}")]
        public async Task<IActionResult> GetPostByArtworkId([FromRoute] int artworkId, [FromQuery] QueryPaging queryPaging)
        {
            var result = await _postService.GetPostByArtworkId(artworkId, queryPaging);

            if (result.TotalItems <= 0)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
