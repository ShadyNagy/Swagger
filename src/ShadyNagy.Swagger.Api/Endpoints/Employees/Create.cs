using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ShadyNagy.Swagger.Core.Constants;
using ShadyNagy.Swagger.SharedKernel.Interfaces;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  [Authorize(Roles = AuthorizationConstants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class Create : BaseAsyncEndpoint<CreateEmployeeCommand, CreateEmployeeResult>
  {
    private readonly IRepository _repository;
    private readonly CreateEmployeeAssembler _assembler;

    public Create(IRepository repository, IMapper mapper)
    {
      _repository = repository;
      _assembler = new CreateEmployeeAssembler(mapper);
    }

    [HttpPost("/api/employees")]
    [SwaggerOperation(
      Summary = "Creates a new Employee",
      Description = "Creates a new Employee",
      OperationId = "Employee.Create",
      Tags = new[] { "EmployeeEndpoints" })
    ]
    public override async Task<ActionResult<CreateEmployeeResult>> HandleAsync([FromBody] CreateEmployeeCommand request)
    {
      
      var createdEmployee = _assembler.WriteEntity(request);
      createdEmployee = await _repository.AddAsync(createdEmployee);

      return Ok(_assembler.FromEmployee(createdEmployee));
    }
  }
}
