using ArtHub.BusinessObject;
using ArtHub.Repository.Dependencies;
using ArtHub.Service.Dependencies;

namespace ArtHub.API.Dependencies
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ArtHub2024DbContext>();

            RegisterDIRepository.RegisterDependencies(services);

            RegisterDIService.RegisterDependencies(services);
        }
    }
}
