using ShadyNagy.Swagger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShadyNagy.Swagger.Api.Seeds
{
  public static class SeedData
  {

    public static void Initialize(IServiceProvider serviceProvider)
    {
      using var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

      new EmployeesSeed(dbContext).PopulateTestData();
    }

  }
}
