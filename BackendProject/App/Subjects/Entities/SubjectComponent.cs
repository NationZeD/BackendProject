using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.Entities;

public class SubjectComponent : BaseEntity<SubjectComponentId>
{
    public SubjectId SubjectId { get; set; }
    public ComponentId ComponentId { get; set; }

    private SubjectComponent() : base(new SubjectComponentId(Guid.NewGuid()))
    {
    }

    private SubjectComponent(SubjectId subjectId, ComponentId componentId) : base(
        new SubjectComponentId(Guid.NewGuid()))
    {
        SubjectId = subjectId;
        ComponentId = componentId;
    }

    public static SubjectComponent Create(SubjectId subjectId, ComponentId componentId)
    {
        return new SubjectComponent(subjectId, componentId);
    }
}