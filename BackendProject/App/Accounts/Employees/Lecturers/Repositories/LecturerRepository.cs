using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Accounts.Employees.Lecturers.Repositories;

public class LecturerRepository(ApplicationDbContext db) : BaseEmployeeRepository<Lecturer, LecturerId>(db), ILecturerRepository
{
    public override async Task<Lecturer> GetAsync(LecturerId id)
    {
        return await _db.Lecturers
            .Include(x => x.LecturerComponents)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}