using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.Entities;

public class LecturerComponent : BaseEntity<LecturerComponentId>
{
    public LecturerId LecturerId { get; set; }
    public ComponentId ComponentId { get; set; }

    private LecturerComponent() : base(new LecturerComponentId(Guid.NewGuid()))
    {
    }

    private LecturerComponent(LecturerId lecturerId, ComponentId componentId) : base(
        new LecturerComponentId(Guid.NewGuid()))
    {
        LecturerId = lecturerId;
        ComponentId = componentId;
    }

    public static LecturerComponent Create(LecturerId lecturerId, ComponentId componentId)
    {
        return new LecturerComponent(lecturerId, componentId);
    }
}