using BackendProject.App.Multilinguals.Dtos;
using BackendProject.App.Subjects.Entities;
using BackendProject.App.SystemFiles.Dtos;

namespace BackendProject.App.Subjects.Dtos;

public class SubjectForm
{
    public Guid? Id { get; set; }
    public MultiLingualInput Name { get; set; }
    public FileDto Image { get; set; }
    public string Code { get; set; }
    public List<SubjectComponentDto> SubjectComponents { get; set; }

    public void Read(Subject entity)
    {
        Id = entity.Id.Value;
        Name.Read(entity.Name);
        Code = entity.Code;
        Image = null;
        
        foreach (var subjectComponent in entity.SubjectComponents)
        {
            var subjectComponentDto = new SubjectComponentDto();
            subjectComponentDto.ComponentId = subjectComponent.ComponentId.Value;
            subjectComponentDto.SubjectId = subjectComponent.SubjectId.Value;
            subjectComponentDto.Id = subjectComponent.Id.Value;
            SubjectComponents.Add(subjectComponentDto);
        }
    }

    public static SubjectForm GetNewInstance()
    {
        return new SubjectForm
        {
            Id = null,
            Name = MultiLingualInput.GetNewInstance(),
            Image = new FileDto(),
            Code = null,
            SubjectComponents = []
        };
    }
}