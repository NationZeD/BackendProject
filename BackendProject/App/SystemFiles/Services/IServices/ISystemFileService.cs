using BackendProject.App.SystemFiles.Dtos;
using BackendProject.App.SystemFiles.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.SystemFiles.Services.IServices;

public interface ISystemFileService : IAppService
{
    Task<SystemFile> UploadFileAsync(IFormFile file);
    Task<DownloadedFile> DownloadFileAsync(SystemFile file);
}