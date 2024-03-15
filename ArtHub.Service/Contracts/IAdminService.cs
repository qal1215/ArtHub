using ArtHub.DTO.AccountDTO;

namespace ArtHub.Service.Contracts
{
    public interface IAdminService
    {
        Task<ViewAccount?> GetUserByEmail(string userEmail);
    }
}
