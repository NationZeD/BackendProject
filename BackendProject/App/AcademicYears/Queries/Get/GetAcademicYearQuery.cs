using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.Shared.Abstractions.CRUD.Queries.Get;

namespace BackendProject.App.AcademicYears.Queries.Get;

public class GetAcademicYearQuery : BaseGetQuery<AcademicYear, AcademicYearDto>
{
    public GetAcademicYearQuery(Guid id) : base(id)
    {
    }
}