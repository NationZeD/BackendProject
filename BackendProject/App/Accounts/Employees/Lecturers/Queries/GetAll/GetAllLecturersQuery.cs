using BackendProject.App.Accounts.Employees.BaseEmployee.Queries.GetAll;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;

namespace BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAll;

public class GetAllLecturersQuery : BaseEmployeeGetAllQuery<Lecturer, LecturerDto>;