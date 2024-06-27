using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;

public class BaseEmployeeGetAllQueryHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest, List<TDto>>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TRequest : BaseEmployeeGetAllQuery<TEntity, TDto>
{
    private readonly IBaseEmployeeReadRepository<TDto> _repo;

    public BaseEmployeeGetAllQueryHandler(IBaseEmployeeReadRepository<TDto> repo)
    {
        _repo = repo;
    }

    public async Task<List<TDto>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}