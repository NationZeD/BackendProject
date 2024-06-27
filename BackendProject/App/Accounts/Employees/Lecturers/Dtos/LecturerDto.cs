using BackendProject.App.Components.Dtos;

namespace BackendProject.App.Accounts.Employees.Lecturers.Dtos;

public class LecturerDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string PersonalId { get; set; }
    public List<ComponentDto> Components { get; set; }
}