using BackendProject.App.SystemFiles.Dtos;
using MediatR;

namespace BackendProject.App.SystemFiles.Commands.Upload;

public class UploadFileCommand(IFormFile file) : IRequest<FileDto>
{
    public IFormFile File { get; set; } = file;
}