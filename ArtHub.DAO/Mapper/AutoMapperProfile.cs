using ArtHub.BusinessObject;
using ArtHub.DAO.AccountDTO;
using ArtHub.DAO.ArtworkDTO;
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

            CreateMap<CreateArtwork, Artwork>();
        }
    }
}
