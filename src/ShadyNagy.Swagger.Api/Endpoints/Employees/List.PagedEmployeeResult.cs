using System.Collections.Generic;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class PagedEmployeeResult
    {
    public int Page { get; }
    public int TotalRecords { get; }
    public IEnumerable<EmployeeDto> Employees { get; }

    public PagedEmployeeResult(int page, int totalRecords, IEnumerable<EmployeeDto> employees)
    {
      Page = page < 0? 0: page;
      TotalRecords = totalRecords;
      Employees = employees;
    }
  }
}
