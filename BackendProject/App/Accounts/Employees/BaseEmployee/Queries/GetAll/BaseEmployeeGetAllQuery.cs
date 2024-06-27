using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;

public class BaseEmployeeGetAllQuery<TEntity, TDto> : IRequest<List<TDto>>;