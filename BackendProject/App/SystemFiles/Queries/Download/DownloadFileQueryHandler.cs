using BackendProject.App.SystemFiles.Dtos;
using BackendProject.App.SystemFiles.Repositories.IRepositories;
using BackendProject.App.SystemFiles.Services.IServices;
using BackendProject.App.SystemFiles.ValueObjects;
using MediatR;

namespace BackendProject.App.SystemFiles.Queries.Download;

public class DownloadFileQueryHandler(ISystemFileRepository repository, ISystemFileService service)
    : IRequestHandler<DownloadFileQuery, DownloadedFile>
{
    public async Task<DownloadedFile> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
    {
        var file = await repository.GetAsync(new SystemFileId(request.Id));
        if (file == null)
            throw new Exception("File not found");
        
        return await service.DownloadFileAsync(file);
    }
}