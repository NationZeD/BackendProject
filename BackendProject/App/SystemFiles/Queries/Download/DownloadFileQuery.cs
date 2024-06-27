using BackendProject.App.SystemFiles.Dtos;
using MediatR;

namespace BackendProject.App.SystemFiles.Queries.Download;

public class DownloadFileQuery(Guid id) : IRequest<DownloadedFile>
{
    public Guid Id { get; set; } = id;
}