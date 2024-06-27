using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

public class BaseLanguagedGetQuery<TEntity, TForm>(Guid id) : IRequest<TForm>
    where TForm : IForm<TEntity>
{
    public Guid Id { get; private set; } = id;
}