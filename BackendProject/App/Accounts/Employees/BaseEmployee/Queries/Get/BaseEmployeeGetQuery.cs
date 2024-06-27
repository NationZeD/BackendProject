using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.Get;

public class BaseEmployeeGetQuery<TEntity, TDto> : IRequest<TDto> 
{
    public Guid Id { get; private set; }

    public BaseEmployeeGetQuery(Guid id)
    {
        Id = id;
    }
}