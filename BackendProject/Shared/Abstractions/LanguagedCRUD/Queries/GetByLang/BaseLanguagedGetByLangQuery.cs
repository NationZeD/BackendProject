using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

public class BaseLanguagedGetByLangQuery<TEntity, TDto>(Guid id, string lang) : IRequest<TDto>
{
    public Guid Id { get; private set; } = id;
    public string Lang { get; private set; } = lang;
}