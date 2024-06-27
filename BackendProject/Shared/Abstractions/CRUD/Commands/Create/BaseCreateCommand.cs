using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Create;

public abstract class BaseCreateCommand<TEntity, TDto>(TDto request) : IRequest
    where TDto : ICrudDTO<TEntity>
{
    public TDto Request { get; private set; } = request;
}