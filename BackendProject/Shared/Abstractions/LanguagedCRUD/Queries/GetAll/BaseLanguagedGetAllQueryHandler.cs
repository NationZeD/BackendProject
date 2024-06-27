using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

public class BaseLanguagedGetAllQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, List<TDto>>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TRequest : BaseLanguagedGetAllQuery<TEntity, TDto>
{
    private readonly ILanguagedReadRepository<TDto> _repo;

    public BaseLanguagedGetAllQueryHandler(ILanguagedReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<List<TDto>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync(request.Lang);
    }
}