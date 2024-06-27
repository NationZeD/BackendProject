using BackendProject.App.AcademicYears.Commands.Create;
using BackendProject.App.AcademicYears.Commands.Delete;
using BackendProject.App.AcademicYears.Commands.Edit;
using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Queries.Get;
using BackendProject.App.AcademicYears.Queries.GetAll;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD;
using MediatR;

namespace BackendProject.App.AcademicYears.Controllers.V1;

public class AcademicYearsController : BaseCrudController<AcademicYear, AcademicYearId, AcademicYearDto>
{
    public AcademicYearsController(IMediator mediator) : base(mediator)
    {
    }

    protected override async Task GenerateCreateAsync(AcademicYearDto dto)
    {
        await _mediator.Send(new CreateAcademicYearCommand(dto));
    }

    protected override async Task GenerateUpdateAsync(AcademicYearDto dto)
    {
        await _mediator.Send(new UpdateAcademicYearCommand(dto));
    }

    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteAcademicYearCommand(new AcademicYearId(id)));
    }

    protected override async Task<AcademicYearDto> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetAcademicYearQuery(id));
    }

    protected override async Task<List<AcademicYearDto>> GenerateGetAllAsync()
    {
        return await _mediator.Send(new GetAllAcademicYearsQuery());
    }
}