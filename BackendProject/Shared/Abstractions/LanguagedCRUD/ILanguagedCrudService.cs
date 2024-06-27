namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

public interface ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> : IAppService
    where TEntity : BaseEntity<TEntityId> where TEntityId : BaseEntityId where TForm : IForm<TEntity>
{
    Task CreateAsync(TForm form);

    Task UpdateAsync(TForm form);

    Task DeleteAsync(TEntityId id);

    Task<TForm> GetAsync(TEntityId id);

    Task<List<TDto>> GetAllAsync(string lang);

    TForm GetForm();
}