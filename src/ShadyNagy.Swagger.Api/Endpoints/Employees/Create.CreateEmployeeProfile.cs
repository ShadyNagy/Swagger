using ShadyNagy.Swagger.Core.Entities;
using AutoMapper;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class CreateEmployeeProfile : Profile
  {
    public CreateEmployeeProfile()
    {
      CreateMap<CreateEmployeeCommand, Employee>();
      CreateMap<Employee, CreateEmployeeResult>();
    }
  }
}
