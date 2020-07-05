using ShadyNagy.Swagger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShadyNagy.Swagger.Infrastructure.Identity;

namespace ShadyNagy.Swagger.Infrastructure
{
  public static class StartupSetup
  {
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString)); // will be created in web project root

    public static void AddIdentityDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppIdentityDbContext>(options =>
        options.UseSqlServer(connectionString)); // will be created in web project root
  }
}
