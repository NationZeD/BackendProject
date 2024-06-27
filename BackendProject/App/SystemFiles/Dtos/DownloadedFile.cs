namespace BackendProject.App.SystemFiles.Dtos;

public record DownloadedFile(string FileName, string FileExtension, byte[] Data);