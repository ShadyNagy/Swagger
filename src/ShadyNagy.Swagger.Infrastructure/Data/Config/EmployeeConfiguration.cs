using ShadyNagy.Swagger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShadyNagy.Swagger.Infrastructure.Data.Config
{
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.Property(t => t.UserId)
          .IsRequired();
      builder.Property(t => t.Username)
          .IsRequired();
      builder.Property(t => t.FullName)
          .IsRequired();
    }
  }
}
