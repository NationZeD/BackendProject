using BackendProject.App.SystemFiles.Commands.Upload;
using BackendProject.App.SystemFiles.Queries.Download;
using BackendProject.Shared;
using BackendProject.Shared.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.App.SystemFiles.Controllers.V1;
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[EnableCors(ProjectEnvironment.DefaultPolicy)]
[ApiController]
public class FilesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var result = await mediator.Send(new UploadFileCommand(file));
        return Ok(ServiceResponse.SucceededInstance(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Download(Guid id)
    {
        var file = await mediator.Send(new DownloadFileQuery(id));
        return File(file.Data, file.FileExtension, file.FileName);
    }
}