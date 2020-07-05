using System.Linq;
using ShadyNagy.Swagger.Core.Entities;
using ShadyNagy.Swagger.Infrastructure.Data;

namespace ShadyNagy.Swagger.Api.Seeds
{
  public class EmployeesSeed : ISeedData
  {
    public static readonly Employee Employee1 = new Employee
    {
        FullName = "Admin Admin",
        UserId = "a4b665b6-3c25-4c54-a425-201ba1e86c73"
    };
    private readonly AppDbContext _dbContext;

    public EmployeesSeed(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void PopulateTestData()
    {
      if (HasData())
      {
        return;
      }

      _dbContext.RemoveRange(_dbContext.Employee);
      
      _dbContext.SaveChanges();
      _dbContext.Employee.Add(Employee1);

      _dbContext.SaveChanges();
    }

    private bool HasData()
    {
      return _dbContext.Employee.Any();
    }
  }
}
