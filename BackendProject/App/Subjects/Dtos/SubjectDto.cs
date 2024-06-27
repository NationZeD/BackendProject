using BackendProject.App.SystemFiles.Dtos;

namespace BackendProject.App.Subjects.Dtos;

public class SubjectDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public FileDto Image { get; set; }
    public string Code { get; set; }
    public List<SubjectComponentDto> SubjectComponents { get; set; }
}