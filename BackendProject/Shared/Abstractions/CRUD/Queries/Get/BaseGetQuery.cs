using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Queries.Get;

public class BaseGetQuery<TEntity, TDto> : IRequest<TDto> where TDto : ICrudDTO<TEntity>
{
    public Guid Id { get; private set; }

    public BaseGetQuery(Guid id)
    {
        Id = id;
    }
}