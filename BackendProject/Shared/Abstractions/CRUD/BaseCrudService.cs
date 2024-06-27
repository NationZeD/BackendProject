namespace BackendProject.Shared.Abstractions.CRUD;

public abstract class BaseCrudService<TEntity, TEntityId, TDto> : ICrudService<TEntity, TEntityId, TDto>
    where TEntity : BaseEntity<TEntityId> where TEntityId : BaseEntityId where TDto : ICrudDTO<TEntity>
{
    private readonly IBaseRepository<TEntity, TEntityId> _repository;
    private readonly IReadRepository<TDto> _readRepository;

    protected BaseCrudService(IBaseRepository<TEntity, TEntityId> repository, IReadRepository<TDto> readRepository)
    {
        _repository = repository;
        _readRepository = readRepository;
    }

    public async Task CreateAsync(TDto dto)
    {
        var entity = await GenerateEntityAsync(dto);
        dto.Write(entity);
        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = await GenerateEntityAsync(dto);
        dto.Write(entity);

        _repository.Update(entity);
    }

    public async Task DeleteAsync(TEntityId id)
    {
        var entity = await _repository.GetAsync(id);
        if (entity == null)
            throw new Exception("No records were found with given parameters");

        _repository.Delete(entity);
    }

    public async Task<TDto> GetAsync(TEntityId id)
    {
        var result = await _readRepository.GetAsync(id.Value);
        if (result == null)
            throw new Exception("No records were found with given parameters");
        return result;
    }

    public async Task<List<TDto>> GetAllAsync()
    {
        return await _readRepository.GetAllAsync();
    }

    protected abstract Task<TEntity> GenerateEntityAsync(TDto dto);
}