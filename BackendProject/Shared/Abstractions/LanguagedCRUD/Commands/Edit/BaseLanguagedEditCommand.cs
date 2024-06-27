using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

public class BaseLanguagedEditCommand<TEntity, TEntityId, TForm, TDto>(TForm request) : IRequest
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
{
    public TForm Request { get; private set; } = request;
}