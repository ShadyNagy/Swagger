using Microsoft.AspNetCore.Identity;
using ShadyNagy.Swagger.Core.Constants;
using System.Threading.Tasks;

namespace ShadyNagy.Swagger.Infrastructure.Identity
{
  public class AppIdentityDbContextSeed
  {
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));

      string defaultUserName = "normal@swagger.test";
      var defaultUser = new ApplicationUser { UserName = defaultUserName, Email = defaultUserName };
      await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

      string adminUserName = "admin@swagger.test";
      var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
      await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
      adminUser = await userManager.FindByNameAsync(adminUserName);
      await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
    }
  }
}
