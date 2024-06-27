using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

public class BaseLanguagedGetFormQueryHandler<TEntity, TEntityId, TForm, TDto, TRequest> : IRequestHandler<TRequest, TForm>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
    where TRequest : BaseLanguagedGetFormQuery<TEntity, TForm>
{
    private readonly ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> _languagedCrudService;

    public BaseLanguagedGetFormQueryHandler(ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> languagedCrudService)
    {
        _languagedCrudService = languagedCrudService;
    }

    public async Task<TForm> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return _languagedCrudService.GetForm();
    }
}