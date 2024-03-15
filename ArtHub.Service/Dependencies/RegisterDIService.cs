using ArtHub.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ArtHub.Service.Dependencies
{
    public class RegisterDIService
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IArtworkService, ArtworkService>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IFollowService, FollowService>();
        }
    }
}
