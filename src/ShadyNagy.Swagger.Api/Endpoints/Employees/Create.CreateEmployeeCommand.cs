using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.Swagger.Api.Endpoints.Employees
{
  public class CreateEmployeeCommand
  {
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string UserId { get; set; } = string.Empty;
  }
}
