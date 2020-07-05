using MediatR;
using System;

namespace ShadyNagy.Swagger.SharedKernel
{
  public abstract class BaseDomainEvent : INotification
  {
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
  }
}
