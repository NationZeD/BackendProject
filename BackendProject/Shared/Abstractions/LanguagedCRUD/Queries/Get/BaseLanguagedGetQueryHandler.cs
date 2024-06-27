using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

public class BaseLanguagedGetQueryHandler<TEntity, TEntityId, TForm, TDto, TRequest>(
    ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> languagedCrudService)
    : IRequestHandler<TRequest, TForm>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId, new()
    where TForm : IForm<TEntity>
    where TRequest : BaseLanguagedGetQuery<TEntity, TForm>
{
    public async Task<TForm> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await languagedCrudService.GetAsync(BaseEntityId.Parse<TEntityId>(request.Id));
    }
}