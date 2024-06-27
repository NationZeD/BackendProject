using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

public class BaseLanguagedGetByLangQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, TDto>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TRequest : BaseLanguagedGetByLangQuery<TEntity, TDto>
{
    private readonly ILanguagedReadRepository<TDto> _repo;

    public BaseLanguagedGetByLangQueryHandler(ILanguagedReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdByLangAsync(request.Id, request.Lang);
    }
}