using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

public record LecturerId : BaseEntityId
{
    public LecturerId()
    {
        
    }

    public LecturerId(Guid value) : base(value)
    {
        
    }

    public static LecturerId New => new LecturerId(Guid.NewGuid());
}