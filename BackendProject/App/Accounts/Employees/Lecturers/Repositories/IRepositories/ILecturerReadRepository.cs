using BackendProject.App.Accounts.Employees.BaseEmployee.Repositories.IRepositories;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;
using BackendProject.Shared.Paging;

namespace BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;

public interface ILecturerReadRepository : IBaseEmployeeReadRepository<LecturerDto>
{
    Task<LecturerDto> GetAsync(Guid id, string lang);
    Task<PagedList<LecturerDto>> FilterAsync(LecturerPagingQuery query);
    Task<List<LecturerDto>> GetAllAsync(string lang);
}