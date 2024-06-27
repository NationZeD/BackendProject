using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;

public class BaseEmployeeGetByUsernameQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, TDto>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TRequest : BaseEmployeeGetByUserNameQuery<TEntity, TDto>
{
    private readonly IBaseEmployeeReadRepository<TDto> _repo;

    public BaseEmployeeGetByUsernameQueryHandler(IBaseEmployeeReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetByUserNameAsync(request.UserName);
    }
}