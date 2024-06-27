using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.ValueObjects;

public record SubjectId : BaseEntityId
{
    public SubjectId()
    {
    }

    public SubjectId(Guid value) : base(value)
    {
    }

    public static SubjectId New => new SubjectId(Guid.NewGuid());
}