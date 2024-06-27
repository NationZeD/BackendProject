using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Repositories.IRepositories;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD.Queries.GetAll;

namespace BackendProject.App.AcademicYears.Queries.GetAll;

public class GetAllAcademicYearsQueryHandler : BaseGetAllQueryHandler
    <AcademicYear, AcademicYearId, AcademicYearDto, GetAllAcademicYearsQuery>
{
    public GetAllAcademicYearsQueryHandler(IAcademicYearReadRepository repo) : base(repo)
    {
    }
}