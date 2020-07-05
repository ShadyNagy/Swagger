using ShadyNagy.Swagger.Core.Entities;
using AutoMapper;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class ListEmployeeProfile : Profile
  {
    public ListEmployeeProfile()
    {
      CreateMap<Employee, EmployeeDto>();
    }
  }
}
