using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD.Commands.Delete;

namespace BackendProject.App.AcademicYears.Commands.Delete;

public class DeleteAcademicYearCommand : BaseDeleteCommand<AcademicYear, AcademicYearId, AcademicYearDto>
{
    public DeleteAcademicYearCommand(AcademicYearId id) : base(id)
    {
    }
}