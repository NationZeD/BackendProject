using BackendProject.App.SystemFiles.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.SystemFiles.Entities;

public class SystemFile(SystemFileId id, string fileName, string fileExtension, string fileUrl)
    : BaseEntity<SystemFileId>(id)
{
    public string? FileName { get; set; } = fileName;
    public string? FileExtension { get; set; } = fileExtension;
    public string? FileUrl { get; set; } = fileUrl;
}