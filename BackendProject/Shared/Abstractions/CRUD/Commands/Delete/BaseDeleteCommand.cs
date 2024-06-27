using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Delete;

public class BaseDeleteCommand<TEntity, TEntityId, TDto> : IRequest
    where TDto : ICrudDTO<TEntity> where TEntityId : BaseEntityId
{
    public TEntityId Id { get; private set; }

    public BaseDeleteCommand(TEntityId id)
    {
        Id = id;
    }
}