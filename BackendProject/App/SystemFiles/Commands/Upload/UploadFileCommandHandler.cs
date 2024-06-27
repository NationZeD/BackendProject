using BackendProject.App.SystemFiles.Dtos;
using BackendProject.App.SystemFiles.Repositories.IRepositories;
using BackendProject.App.SystemFiles.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.SystemFiles.Commands.Upload;

public class UploadFileCommandHandler(
    ISystemFileRepository repository,
    ISystemFileService service,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UploadFileCommand, FileDto>
{
    public async Task<FileDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var file = await service.UploadFileAsync(request.File);
        await repository.CreateAsync(file);
        await unitOfWork.SaveAsync();
        return new FileDto(file);
    }
}