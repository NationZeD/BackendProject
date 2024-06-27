using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

public class BaseLanguagedCreateCommand<TEntity, TEntityId, TForm, TDto>(TForm request) : IRequest
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
{
    public TForm Request { get; private set; } = request;
}