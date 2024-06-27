using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

public class BaseLanguagedDeleteCommand<TEntity, TEntityId, TForm, TDto>(TEntityId id) : IRequest
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
{
    public TEntityId Id { get; private set; } = id;
}