using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.Shared.Abstractions.CRUD.Commands.Create;

namespace BackendProject.App.AcademicYears.Commands.Create;

public class CreateAcademicYearCommand : BaseCreateCommand<AcademicYear, AcademicYearDto>
{
    public CreateAcademicYearCommand(AcademicYearDto request) : base(request)
    {
    }
}