using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Queries.GetAll;

public class BaseGetAllQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, List<TDto>>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
    where TRequest : BaseGetAllQuery<TEntity, TDto>
{
    private readonly IReadRepository<TDto> _repo;

    public BaseGetAllQueryHandler(IReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<List<TDto>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}