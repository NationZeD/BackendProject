using BackendProject.App.SystemFiles.Entities;

namespace BackendProject.App.SystemFiles.Dtos;

public class FileDto
{
    public Guid Id { get; set; }
    public string? FileName { get; set; }
    public string? FileExtension { get; set; }
    public string? FileURL { get; set; }

    public FileDto()
    {
    }

    public FileDto(SystemFile file)
    {
        Id = file.Id.Value;
        FileName = file.FileName;
        FileExtension = file.FileExtension;
        FileURL = file.FileUrl;
    }
}