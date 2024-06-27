namespace BackendProject.Shared.Abstractions.CRUD;

public interface ICrudService<TEntity, TEntityId, TDto> : IAppService where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
{
    Task CreateAsync(TDto dto);

    Task UpdateAsync(TDto dto);

    Task DeleteAsync(TEntityId id);

    Task<TDto> GetAsync(TEntityId id);

    Task<List<TDto>> GetAllAsync();
}