using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.Shared.Abstractions.CRUD.Commands.Edit;

namespace BackendProject.App.AcademicYears.Commands.Edit;

public class UpdateAcademicYearCommand : BaseEditCommand<AcademicYear, AcademicYearDto>
{
    public UpdateAcademicYearCommand(AcademicYearDto request) : base(request)
    {
    }
}