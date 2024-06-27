using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

public class BaseLanguagedGetAllQuery<TEntity, TDto>(string lang) : IRequest<List<TDto>>
{
    public string Lang { get; set; } = lang;
}