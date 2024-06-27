using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Repositories;

public abstract class BaseEmployeeRepository<TMember, TId>(ApplicationDbContext db)
    : BaseRepository<TMember, TId>(db), IBaseEmployeeRepository<TMember, TId>
    where TMember : BaseEmployee<TId>
    where TId : BaseEntityId
{
    public async Task<bool> ExistsAsync(string username)
    {
        return await _db.Set<TMember>().AnyAsync(x => x.UserName == username);
    }

    public async Task<TMember> GetAsync(string username)
    {
        return await _db.Set<TMember>().FirstOrDefaultAsync(x => x.UserName == username);
    }
}