using ArtHub.BusinessObject;
using ArtHub.DAO.AccountDTO;
using ArtHub.DAO.ArtworkDTO;
using ArtHub.DAO.BalanceDTO;
using ArtHub.DAO.PostCommentDTO;
using ArtHub.DAO.RatingDTO;
using AutoMapper;

namespace ArtHub.DAO.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginDTO, ViewAccountDTO>();
            CreateMap<ViewAccountDTO, LoginDTO>();
            CreateMap<Register, Member>();
            CreateMap<UpdateAccount, Member>();
            CreateMap<Member, ViewAccount>();

            CreateMap<CreateArtwork, Artwork>();
            CreateMap<UpdateArtwork, Artwork>();

            CreateMap<CreatePost, Post>();
            CreateMap<UpdatePost, Post>();
            CreateMap<CreateComment, Comment>();
            CreateMap<UpdateComment, Comment>();

            CreateMap<Member, CurrentBalance>();
            CreateMap<PostRating, Rating>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating));

            CreateMap<Artwork, ViewArtwork>();
        }
    }
}
