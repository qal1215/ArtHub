using ArtHub.BusinessObject;
using ArtHub.DAO.AccountDTO;
using ArtHub.DAO.ArtworkDTO;
using ArtHub.DAO.BalanceDTO;
using ArtHub.DAO.OrderDTO;
using ArtHub.DAO.PostCommentDTO;
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

            CreateMap<CreatePost, Post>();
            CreateMap<CreateComment, Comment>();

            CreateMap<Member, CurrentBalance>();
            CreateMap<CreateOrder, Order>();
        }
    }
}
