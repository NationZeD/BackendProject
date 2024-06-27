using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Services.IServices;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.CRUD.Commands.Delete;

namespace BackendProject.App.AcademicYears.Commands.Delete;

public class DeleteAcademicYearCommandHandler : BaseDeleteCommandHandler
    <AcademicYear, AcademicYearId, AcademicYearDto, DeleteAcademicYearCommand>
{
    public DeleteAcademicYearCommandHandler(IAcademicYearService service, IUnitOfWork unitOfWork)
        : base(service, unitOfWork)
    {
    }
}