using ArtHub.BusinessObject;
using ArtHub.DTO.AccountDTO;
using ArtHub.DTO.ArtworkDTO;
using ArtHub.DTO.BalanceDTO;
using ArtHub.DTO.PostCommentDTO;
using ArtHub.DTO.RatingDTO;
using AutoMapper;

namespace ArtHub.DTO.Mapper
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
            CreateMap<Post, ViewPost>();
            CreateMap<Comment, ViewComment>();
        }
    }
}
