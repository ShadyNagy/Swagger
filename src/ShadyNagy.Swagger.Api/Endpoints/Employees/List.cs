using Ardalis.ApiEndpoints;
using ShadyNagy.Swagger.Core.Entities;
using ShadyNagy.Swagger.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class List : BaseAsyncEndpoint<int, PagedEmployeeResult>
  {
    private readonly IRepository _repository;
    private readonly ListEmployeeAssembler _assembler;

    public List(IRepository repository, IMapper mapper)
    {
      _repository = repository;
      _assembler = new ListEmployeeAssembler(mapper);
    }


    [HttpGet("/api/employees")]
    [SwaggerOperation(
        Summary = "Gets a list of all Employees by page every page is 25 records",
        Description = "Gets a list of all Employees by page every page is 25 records",
        OperationId = "Employee.List",
        Tags = new[] { "EmployeeEndpoints" })
    ]
    public override async Task<ActionResult<PagedEmployeeResult>> HandleAsync([FromQuery] int page)
    {
      var employees = await _repository.ListAsync<Employee>(page);
      var result = new PagedEmployeeResult(page, employees.Count, employees.Select(_assembler.WriteDto));

      return Ok(result);
    }
  }
}
