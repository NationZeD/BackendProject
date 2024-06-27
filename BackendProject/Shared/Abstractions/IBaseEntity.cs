namespace BackendProject.Shared.Abstractions;

public interface IBaseEntity
{
    IReadOnlyList<IDomainEvent> Events { get; }
    void ClearEvents();
}