using AutoMapper;
using ShadyNagy.Swagger.Core.Entities;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class CreateEmployeeAssembler
  {
    private readonly IMapper _mapper;

    public CreateEmployeeAssembler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public Employee WriteEntity(CreateEmployeeCommand createEmployeeCommand)
    {
      var result = new Employee();
      _mapper.Map(createEmployeeCommand, result);

      return result;
    }

    public CreateEmployeeResult FromEmployee(Employee employee)
    {
      var result = new CreateEmployeeResult();
      _mapper.Map(employee, result);

      return result;
    }
  }
}
