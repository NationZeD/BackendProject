using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Services.IServices;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.CRUD.Commands.Create;

namespace BackendProject.App.AcademicYears.Commands.Create;

public class CreateAcademicYearCommandHandler : BaseCreateCommandHandler
    <AcademicYear, AcademicYearId, AcademicYearDto, CreateAcademicYearCommand>
{
    public CreateAcademicYearCommandHandler(IAcademicYearService service, IUnitOfWork unitOfWork)
        : base(service, unitOfWork)
    {
    }
}