using ArtHub.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ArtHub.Repository.Dependencies
{
    public static class RegisterDIRepository
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IArtworkRepository, ArtworkRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
        }
    }
}
