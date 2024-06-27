using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BackendProject.App.SystemFiles.Dtos;
using BackendProject.App.SystemFiles.Entities;
using BackendProject.App.SystemFiles.Services.IServices;
using BackendProject.App.SystemFiles.ValueObjects;

namespace BackendProject.App.SystemFiles.Services;

public class SystemFileService(BlobServiceClient client) : ISystemFileService
{
    public async Task<SystemFile> UploadFileAsync(IFormFile file)
    {
        var blobContainerClient = client.GetBlobContainerClient("backendprojectcontainer");
        var blobClient = blobContainerClient.GetBlobClient($"{Guid.NewGuid().ToString()}-{file.FileName}");

        var httpHeaders = new BlobHttpHeaders()
        {
            ContentType = file.ContentType
        };

        await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
        var systemFile = new SystemFile(new SystemFileId(Guid.NewGuid()), file.FileName, file.ContentType,
            blobClient?.Uri.AbsoluteUri)
        {
            FileUrl = blobClient?.Uri.AbsoluteUri,
            FileExtension = file.ContentType,
            FileName = file.FileName
        };
        
        return systemFile;
    }

    public async Task<DownloadedFile> DownloadFileAsync(SystemFile file)
    {
        var content = await new HttpClient().GetStreamAsync(file.FileUrl);
        var ms = new MemoryStream();
        await content.CopyToAsync(ms);
        return new DownloadedFile(file.FileName, file.FileExtension, ms.ToArray());
    }
}