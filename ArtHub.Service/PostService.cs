using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using ArtHub.DAO.PostCommentDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using ArtHub.Service.Helper;
using AutoMapper;

namespace ArtHub.Service
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IArtworkRepository _artworkRepository;

        public PostService(IMapper mapper, IAccountRepository accountRepository,
            IPostRepository postRepository, ICommentRepository commentRepository,
            IArtworkRepository artworkRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _accountRepository = accountRepository;
            _artworkRepository = artworkRepository;
        }
        public async Task<Post> AddPostAsync(CreatePost post)
        {
            var user = await _accountRepository.IsExistedAccount(post.MemberId);
            if (!user)
            {
                throw new Exception("User not found");
            }

            var artwork = await _artworkRepository.IsExistArtwork(post.ArtworkId);
            if (!artwork)
            {
                throw new Exception("Artwork not found");
            }

            Post creating = _mapper.Map<Post>(post);
            return await _postRepository.AddPostAsync(creating);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            return await _postRepository.DeletePostAsync(postId);
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            var post = await _postRepository.GetPostAsyns(postId);

            if (post is null) return null;

            post.Comments = await _commentRepository.GetCommentsByPostId(postId);
            return post;
        }

        public Task<List<Post>?> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Post?> UpdatePostAsync(int postId, UpdatePost updatePost)
        {
            var post = _mapper.Map<Post>(updatePost);
            var isExist = await _postRepository.IsExisted(postId);
            if (!isExist)
            {
                return null;
            }

            return await _postRepository.UpdatePostAsync(postId, post);
        }

        public async Task<bool> IsExisted(int postId)
            => await _postRepository.IsExisted(postId);


        public async Task<PagedResult<Post>> GetPostByUserId(int userId, QueryPaging queryPaging)
            => await _postRepository.GetPostsByArtistIdAsync(userId, queryPaging.CheckQueryPaging());


        public async Task<PagedResult<Post>> GetPostByArtworkId(int artworkId, QueryPaging queryPaging)
            => await _postRepository.GetPostsByArtworkIdAsync(artworkId, queryPaging.CheckQueryPaging());
    }
}
