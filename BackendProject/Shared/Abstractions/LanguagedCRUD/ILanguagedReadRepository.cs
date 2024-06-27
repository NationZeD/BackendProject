namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

public interface ILanguagedReadRepository<TDto> : IRepository
{
    Task<List<TDto>> GetAllAsync(string lang);
    Task<TDto> GetByIdByLangAsync(Guid id, string lang);
}