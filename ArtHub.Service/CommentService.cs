using ArtHub.BusinessObject;
using ArtHub.DTO.PostCommentDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IAccountRepository _accountRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository
            , IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Comment> AddCommentAsync(CreateComment comment)
        {
            Comment addComment = _mapper.Map<Comment>(comment);
            return await _commentRepository.AddCommentAsync(addComment);
        }

        public async Task DeleteCommentAsync(int commentId)
            => await _commentRepository.DeleteCommentAsync(commentId);

        public async Task<ViewComment?> GetCommentById(int commentId)
        {
            var comment = await _commentRepository.GetCommentAsync(commentId);
            if (comment is null) return null;

            var viewComment = _mapper.Map<ViewComment>(comment);
            var user = await _accountRepository.GetBranchAccountByIdAsync(viewComment.MemberId);
            if (user != null)
            {
                viewComment.MemberName = user.FullName;
                viewComment.MemberAvatar = user.Avatar;
            }

            return viewComment;
        }

        public async Task<IEnumerable<ViewComment>> GetCommentsByPostId(int postId)
        {
            var comment = await _commentRepository.GetCommentsByPostId(postId);
            var viewComment = _mapper.Map<List<ViewComment>>(comment);
            foreach (var item in viewComment)
            {
                var user = await _accountRepository.GetBranchAccountByIdAsync(item.MemberId);

                if (user != null)
                {
                    item.MemberName = user.FullName;
                    item.MemberAvatar = user.Avatar;
                }
            }

            return viewComment;
        }

        public async Task<Comment?> UpdateCommentAsync(int commentId, UpdateComment updateComment)
        {
            Comment comment = _mapper.Map<Comment>(updateComment);
            return await _commentRepository.UpdateCommentAsync(commentId, comment);
        }
    }
}
