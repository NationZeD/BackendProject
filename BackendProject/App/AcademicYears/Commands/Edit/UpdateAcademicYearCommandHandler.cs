using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Services.IServices;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.CRUD.Commands.Edit;

namespace BackendProject.App.AcademicYears.Commands.Edit;

public class UpdateAcademicYearCommandHandler : BaseEditCommandHandler
    <AcademicYear, AcademicYearId, AcademicYearDto, UpdateAcademicYearCommand>
{
    public UpdateAcademicYearCommandHandler(IAcademicYearService service, IUnitOfWork unitOfWork)
        : base(service, unitOfWork)
    {
    }
}