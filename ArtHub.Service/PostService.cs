using ArtHub.BusinessObject;
using ArtHub.DAO.PostCommentDTO;
using ArtHub.Repository;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = new PostRepository();
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
            return await _postRepository.GetPost(postId);
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
