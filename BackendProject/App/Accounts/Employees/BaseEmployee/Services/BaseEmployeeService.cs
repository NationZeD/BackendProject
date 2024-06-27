using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Exceptions;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Services;

public abstract class BaseEmployeeService<TBaseEmployee, TId, TRepository>(TRepository repository)
    : IBaseEmployeeService<TBaseEmployee, TId>
    where TBaseEmployee : BaseEmployee<TId>
    where TId : BaseEntityId, new()
    where TRepository : IBaseEmployeeRepository<TBaseEmployee, TId>
{
    public async Task<bool> ExistsAsync(string username)
    {
        return await repository.ExistsAsync(username);
    }

    public async Task<TId> CreateAsync(ICreateEmployeeRequest<TBaseEmployee, TId> request)
    {
        if (await repository.ExistsAsync(request.UserName))
            throw new NotFoundException("Employee");
        
        var employee = GenerateEmployee(request);
        
        request.Write(employee);
        await repository.CreateAsync(employee);

        return employee.Id;
    }
    
    public async Task UpdateAsync(IUpdateEmployeeRequest<TBaseEmployee, TId> request)
    {
        var employee = await repository.GetAsync(BaseEntityId.Parse<TId>(request.Id));
        if (employee is null)
            throw new NotFoundException("Employee");

        if (employee.UserName != request.UserName)
        {
            if (await repository.ExistsAsync(request.UserName))
                throw new DuplicateInstanceException("Employee");
        }
        
        request.Write(employee);
        repository.Update(employee);
    }

    public async Task DeleteAsync(TId id)
    {
        var member = await repository.GetAsync(id);
        if (member is null)
            throw new NotFoundException("Employee");

        repository.Delete(member);
    }
    
    protected abstract TBaseEmployee GenerateEmployee(ICreateEmployeeRequest<TBaseEmployee, TId> request);
}