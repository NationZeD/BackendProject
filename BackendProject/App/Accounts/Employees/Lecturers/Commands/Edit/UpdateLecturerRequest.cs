using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Annotations;

namespace BackendProject.App.Accounts.Employees.Lecturers.Commands.Edit;

public class UpdateLecturerRequest : IUpdateEmployeeRequest<Lecturer, LecturerId>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [CustomPhoneNumber]
    public string PhoneNumber { get; set; }
    [CustomPersonalId]
    public string PersonalId { get; set; }
    public List<Guid> ComponentIds { get; set; }
    
    public void Write(Lecturer employee)
    {
        employee.UserName = UserName;
        employee.FirstName = FirstName;
        employee.LastName = LastName;
        employee.PhoneNumber = PhoneNumber;
        employee.PersonalId = PersonalId;
        employee.SetComponents(ComponentIds.Select(x => new ComponentId(x)).ToList());
    }
}