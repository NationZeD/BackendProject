namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

public abstract class
    LanguagedCrudService<TEntity, TEntityId, TForm, TDto> : ILanguagedCrudService<TEntity, TEntityId, TForm, TDto>
    where TEntity : BaseEntity<TEntityId> where TEntityId : BaseEntityId where TForm : IForm<TEntity>
{
    private readonly IBaseRepository<TEntity, TEntityId> _repository;
    private readonly ILanguagedReadRepository<TDto> _readRepository;

    protected LanguagedCrudService(IBaseRepository<TEntity, TEntityId> repository,
        ILanguagedReadRepository<TDto> readRepository)
    {
        _repository = repository;
        _readRepository = readRepository;
    }

    public virtual async Task CreateAsync(TForm form)
    {
        var entity = await GenerateEntityAsync(form);
        if (entity == null) throw new Exception("Entity not found.");
        form.Write(entity);
        await _repository.CreateAsync(entity);
    }

    public virtual async Task UpdateAsync(TForm form)
    {
        var entity = await GenerateEntityAsync(form);
        if (entity == null) throw new Exception("Entity not found.");
        form.Write(entity);
        _repository.Update(entity);
    }

    public virtual async Task DeleteAsync(TEntityId id)
    {
        var entity = await _repository.GetAsync(id);
        if (entity is null)
            throw new Exception("No records were found with given parameters");

        _repository.Delete(entity);
    }

    public virtual async Task<TForm> GetAsync(TEntityId id)
    {
        var entity = await _repository.GetAsync(id);
        if (entity is null)
            throw new Exception("No records were found with given parameters");
        var form = GetForm();
        form.Read(entity);
        return form;
    }

    public virtual async Task<List<TDto>> GetAllAsync(string lang)
    {
        return await _readRepository.GetAllAsync(lang);
    }

    public abstract TForm GetForm();
    protected abstract Task<TEntity> GenerateEntityAsync(TForm form);
}