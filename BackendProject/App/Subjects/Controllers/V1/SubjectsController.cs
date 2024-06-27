using Asp.Versioning;
using BackendProject.App.Auth.Constants;
using BackendProject.App.Multilinguals.Dtos;
using BackendProject.App.Subjects.Commands.Create;
using BackendProject.App.Subjects.Commands.Delete;
using BackendProject.App.Subjects.Commands.Edit;
using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Queries.Get;
using BackendProject.App.Subjects.Queries.GetAll;
using BackendProject.App.Subjects.Queries.GetByLang;
using BackendProject.App.Subjects.Queries.GetForm;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.Subjects.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiVersion("1.0")]
public class SubjectsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SubjectForm request)
    {
        await mediator.Send(new CreateSubjectCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] SubjectForm request)
    {
        await mediator.Send(new EditSubjectCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteSubjectCommand(id));
        return Ok(ServiceResponse.SucceededInstance());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await mediator.Send(new GetSubjectQuery(new SubjectId(id)));
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetByLang([FromQuery] BaseLanguagedQuery request)
    {
        var result = await mediator.Send(new GetSubjectByLangQuery(request.Id, request.Lang));
        return Ok(ServiceResponse.SucceededInstance(result));
    }
     
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSubjectsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetForm()
    {
        var result = await mediator.Send(new GetSubjectFormQuery());
        return Ok(ServiceResponse.SucceededInstance(result));
    }
}