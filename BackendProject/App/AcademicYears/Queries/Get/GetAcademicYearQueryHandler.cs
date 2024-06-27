using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Repositories.IRepositories;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD.Queries.Get;

namespace BackendProject.App.AcademicYears.Queries.Get;

public class GetAcademicYearQueryHandler : BaseGetQueryHandler
    <AcademicYear, AcademicYearId, AcademicYearDto, GetAcademicYearQuery>
{
    public GetAcademicYearQueryHandler(IAcademicYearReadRepository repo) : base(repo)
    {
    }
}