using ArtHub.BusinessObject;
using ArtHub.DAO.PostCommentDTO;
using ArtHub.Repository;
using ArtHub.Repository.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper)
        {
            _mapper = mapper;
            _commentRepository = new CommentRepository();
        }

        public async Task<Comment> AddCommentAsync(CreateComment comment)
        {
            Comment addComment = _mapper.Map<Comment>(comment);
            return await _commentRepository.AddCommentAsync(addComment);
        }

        public async Task<Comment?> GetCommentById(int commentId)
        {
            return await _commentRepository.GetCommentAsync(commentId);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await _commentRepository.GetCommentsByPostId(postId);
        }
    }
}
