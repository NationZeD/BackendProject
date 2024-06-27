using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Queries.Get;

public class BaseGetQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, TDto>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
    where TRequest : BaseGetQuery<TEntity, TDto>
{
    private readonly IReadRepository<TDto> _repo;

    public BaseGetQueryHandler(IReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetAsync(request.Id);
    }
}