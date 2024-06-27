namespace BackendProject.Shared.Abstractions;

public interface IBaseRepository<TEntity, TEntityId> : IRepository
    where TEntity : BaseEntity<TEntityId> where TEntityId : BaseEntityId
{
    Task CreateAsync(TEntity entity);
    Task CreateAsync(IEnumerable<TEntity> entities);
    Task<TEntity> GetAsync(TEntityId id);
    Task<List<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    void Update(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void Delete(IEnumerable<TEntity> entities);
}