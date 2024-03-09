using ArtHub.Repository;
using ArtHub.Repository.Contracts;
using ArtHub.Service;
using ArtHub.Service.Contracts;

namespace ArtHub.API.Dependencies
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IArtworkService, ArtworkService>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IArtworkRepository, ArtworkRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
