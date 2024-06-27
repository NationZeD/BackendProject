using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Components.ValueObjects;

namespace BackendProject.App.Accounts.Employees.Lecturers.Entities;

public class Lecturer : BaseEmployee<LecturerId>
{
    public string PhoneNumber { get; set; }
    public string PersonalId { get; set; }
    private List<LecturerComponent> _lecturerComponents = [];
    public IReadOnlyList<LecturerComponent> LecturerComponents => _lecturerComponents.ToList();
    
    public Lecturer() : base(new LecturerId(Guid.NewGuid()))
    {
    }

    private Lecturer(LecturerId id, string firstName, string lastName,
        string userName, string phoneNumber, string personalId, List<ComponentId> components)
        : base(id, userName, firstName, lastName)
    {
        PhoneNumber = phoneNumber;
        PersonalId = personalId;
        _lecturerComponents = [];
        SetComponents(components);
    }

    public static Lecturer Create(LecturerId id, string firstName, string lastName,
        string userName, string phoneNumber, string personalId, List<ComponentId> components)
    {
        return new Lecturer(id, firstName, lastName, userName, phoneNumber, personalId, components);
    }

    public void SetComponents(List<ComponentId> components)
    {
        _lecturerComponents ??= [];

        _lecturerComponents.RemoveAll(x => x.Id != null);

        foreach (var component in components)
            _lecturerComponents.Add(LecturerComponent.Create(Id, component));
    }
}