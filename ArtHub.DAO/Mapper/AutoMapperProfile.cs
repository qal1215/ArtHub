using ArtHub.BusinessObject;
using ArtHub.DTO.AccountDTO;
using ArtHub.DTO.ArtworkDTO;
using ArtHub.DTO.BalanceDTO;
using ArtHub.DTO.FollowDTO;
using ArtHub.DTO.OrderDTO;
using ArtHub.DTO.PostCommentDTO;
using ArtHub.DTO.RatingDTO;
using ArtHub.DTO.ReportDTO;
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
            CreateMap<Artwork, ViewArtwork>();

            CreateMap<CreatePost, Post>();
            CreateMap<UpdatePost, Post>();
            CreateMap<Post, ViewPost>();
            CreateMap<CreateComment, Comment>();
            CreateMap<UpdateComment, Comment>();
            CreateMap<Comment, ViewComment>();

            CreateMap<Member, CurrentBalance>();
            CreateMap<PostRating, Rating>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating));


            CreateMap<CreateOrder, Order>();
            CreateMap<CreateOrderDetail, OrderDetail>();
            CreateMap<Order, ViewOrder>();
            CreateMap<OrderDetail, ViewOrderDetail>();

            CreateMap<CreateReport, Report>();

            CreateMap<CreateFollow, FollowInfos>()
                .ForMember(dest => dest.FolloweeId, opt => opt.MapFrom(src => src.ArtistId));
        }
    }
}
