using BackendProject.App.Accounts.Employees.BaseEmployee.Controllers;
using BackendProject.App.Accounts.Employees.Lecturers.Commands.Create;
using BackendProject.App.Accounts.Employees.Lecturers.Commands.Delete;
using BackendProject.App.Accounts.Employees.Lecturers.Commands.Edit;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.Get;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAll;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.GetAllByLang;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.GetById;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.GetByUserName;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Auth.Constants;
using BackendProject.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Accounts.Employees.Lecturers.Controllers.V1;

public class LecturersController : BaseEmployeeController<Lecturer, LecturerId, LecturerDto, CreateLecturerRequest, UpdateLecturerRequest>
{
    public LecturersController(IMediator mediator) : base(mediator)
    {
        
    }

    [Authorize(Roles = $"{Roles.Admin}")]
    protected override async Task GenerateCreateAsync(CreateLecturerRequest request)
    {
        await _mediator.Send(new CreateLecturerCommand(request));
    }

    [Authorize(Roles = $"{Roles.Admin}")]
    protected override async Task GenerateUpdateAsync(UpdateLecturerRequest request)
    {
        await _mediator.Send(new UpdateLecturerCommand(request));
    }

    [Authorize(Roles = $"{Roles.Admin}")]
    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteLecturerCommand(new LecturerId(id)));
    }

    [Authorize(Roles = $"{Roles.Admin},{Roles.Lecturer}")]
    protected override async Task<LecturerDto> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetLecturerByIdQuery(id));
    }
    
    [Authorize(Roles = $"{Roles.Admin},{Roles.Lecturer}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetLecturerRequest request)
    {
        var result = await _mediator.Send(new GetLecturerQuery(request));
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [Authorize(Roles = $"{Roles.Admin},{Roles.Lecturer}")]
    protected override async Task<LecturerDto> GenerateGetByUserNameAsync(string username)
    {
        return await _mediator.Send(new GetLecturerByUserNameQuery(username));
    }

    [Authorize(Roles = $"{Roles.Admin}")]
    protected override async Task<List<LecturerDto>> GenerateGetAllAsync()
    {
        return await _mediator.Send(new GetAllLecturersQuery());
    }
    
    [Authorize(Roles = $"{Roles.Admin}")]
    [HttpGet("{lang}")]
    public async Task<IActionResult> GetAll(string lang)
    {
        var result = await _mediator.Send(new GetAllLecturersByLangQuery(lang));
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [Authorize(Roles = $"{Roles.Admin}")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Filter([FromQuery] LecturerPagingQuery query)
    {
        var result = await _mediator.Send(new FilterLecturersQuery(query));
        return Ok(ServiceResponse.SucceededInstance(result));
    }
}