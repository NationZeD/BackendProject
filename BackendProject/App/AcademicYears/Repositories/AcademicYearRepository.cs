using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Repositories.IRepositories;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;

namespace BackendProject.App.AcademicYears.Repositories;

public class AcademicYearRepository : BaseRepository<AcademicYear, AcademicYearId>, IAcademicYearRepository
{
    public AcademicYearRepository(ApplicationDbContext db) : base(db)
    {
    }
}