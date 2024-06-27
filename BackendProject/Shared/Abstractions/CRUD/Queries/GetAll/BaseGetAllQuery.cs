using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Queries.GetAll;

public class BaseGetAllQuery<TEntity, TDto> : IRequest<List<TDto>> where TDto : ICrudDTO<TEntity>;