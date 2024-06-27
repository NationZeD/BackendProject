using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.App.SystemFiles.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.Entities;

public class Subject : BaseEntity<SubjectId>
{
    public Multilingual? Name { get; private set; }
    public string? Code { get; set; }
    public SystemFileId ImageId { get; set; }
    private List<SubjectComponent> _subjectComponents = [];
    public IReadOnlyList<SubjectComponent> SubjectComponents => _subjectComponents.ToList();

    private Subject(SubjectId id, SystemFileId imageId, Multilingual name, string code,
        List<ComponentId> components) : base(id)
    {
        ImageId = imageId;
        Name = name;
        Code = code;
        _subjectComponents = [];
        SetComponents(components);
    }

    private Subject() : base(new SubjectId(Guid.NewGuid()))
    {
    }

    public static Subject Create(SubjectId id, SystemFileId photoId, Multilingual name, string code,
        List<ComponentId> components)
    {
        return new Subject(id, photoId, name, code, components);
    }
    
    public void Update(string code, SystemFileId imageId)
    {
        ImageId = imageId;
        Code = code;
    }

    public void SetComponents(List<ComponentId> components)
    {
        if (_subjectComponents is null)
            _subjectComponents = [];

        _subjectComponents.RemoveAll(x => x.Id != null);

        foreach (var component in components)
            _subjectComponents.Add(SubjectComponent.Create(Id, component));
    }
}