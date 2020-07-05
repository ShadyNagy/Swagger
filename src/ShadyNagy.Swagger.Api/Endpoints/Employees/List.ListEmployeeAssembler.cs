using AutoMapper;
using ShadyNagy.Swagger.Core.Entities;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class ListEmployeeAssembler
  {
    private readonly IMapper _mapper;

    public ListEmployeeAssembler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public EmployeeDto WriteDto(Employee employee)
    {
      var result = new EmployeeDto();
      _mapper.Map(employee, result);

      return result;
    }
  }
}
