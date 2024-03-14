using ArtHub.DTO.AccountDTO;
using ArtHub.Service.Contracts;

namespace ArtHub.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAccountService _accountService;

        public AdminService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Task<ViewAccount?> GetUserByEmail(string userEmail)
        {
            return _accountService.GetUserByEmail(userEmail);
        }
    }
}
