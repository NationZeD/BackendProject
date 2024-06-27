namespace BackendProject.Shared.Abstractions.CRUD;

public interface IReadRepository<TDto> : IRepository
{
    Task<TDto> GetAsync(Guid id);
    Task<List<TDto>> GetAllAsync();
}