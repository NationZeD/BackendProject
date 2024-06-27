using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.AcademicYears.Repositories.IRepositories;

public interface IAcademicYearRepository : IBaseRepository<AcademicYear, AcademicYearId>;