using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;

public class BaseEmployeeGetQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, TDto>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TRequest : BaseEmployeeGetQuery<TEntity, TDto>
{
    private readonly IBaseEmployeeReadRepository<TDto> _repo;

    public BaseEmployeeGetQueryHandler(IBaseEmployeeReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetAsync(request.Id);
    }
}