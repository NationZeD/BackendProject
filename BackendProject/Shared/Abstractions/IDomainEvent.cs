using MediatR;

namespace BackendProject.Shared.Abstractions;

public interface IDomainEvent : INotification
{
    object GetValue();
}