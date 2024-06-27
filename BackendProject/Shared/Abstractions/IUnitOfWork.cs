namespace BackendProject.Shared.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}