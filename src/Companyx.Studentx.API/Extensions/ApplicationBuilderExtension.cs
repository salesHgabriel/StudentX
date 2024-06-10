using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Companyx.Studentx.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.MigrateAsync();
        }
    }
}
