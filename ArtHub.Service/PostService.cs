using ArtHub.BusinessObject;
using ArtHub.DAO.PostCommentDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PostService(IMapper mapper, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        public async Task<Post> AddPostAsync(CreatePost post)
        {
            Post creating = _mapper.Map<Post>(post);
            return await _postRepository.AddPostAsync(creating);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            return await _postRepository.DeletePostAsync(postId);
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            var post = await _postRepository.GetPost(postId);

            if (post is null) return null;

            post.Comments = await _commentRepository.GetCommentsByPostId(postId);
            return post;
        }

        public Task<List<Post>?> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Post?> UpdatePostAsync(int postId, Post post)
        {
            var isExist = await _postRepository.IsExisted(postId);
            if (!isExist)
            {
                return null;
            }

            return await _postRepository.UpdatePostAsync(postId, post);
        }

        public async Task<bool> IsExisted(int postId)
        {
            return await _postRepository.IsExisted(postId);
        }

    }
}
