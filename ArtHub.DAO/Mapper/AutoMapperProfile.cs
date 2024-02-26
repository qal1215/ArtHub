using ArtHub.BusinessObject;
using ArtHub.DAO.Account;
using AutoMapper;

namespace ArtHub.DAO.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginDTO, AccountDTO>();
            CreateMap<AccountDTO, LoginDTO>();
            CreateMap<Register, Member>();
        }
    }
}
