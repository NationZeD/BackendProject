using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Edit;

public abstract class BaseEditCommand<TEntity,TDto> : IRequest where TDto: ICrudDTO<TEntity>
{
    public TDto Request { get; private set; }

    protected BaseEditCommand(TDto request)
    {
        Request = request;
    }
}