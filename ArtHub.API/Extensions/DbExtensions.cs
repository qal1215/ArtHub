using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.API.Extensions;

public static class DbExtensions
{
    public static void CreateNewDbIfNotExists(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ArtHub2024DbContext>();
        context?.Database.Migrate();
    }
}
