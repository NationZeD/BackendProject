using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetByUsername;

public class BaseEmployeeGetByUserNameQuery<TEntity, TDto> : IRequest<TDto> 
{
    public string UserName { get; private set; }

    public BaseEmployeeGetByUserNameQuery(string userName)
    {
        UserName = userName;
    }
}