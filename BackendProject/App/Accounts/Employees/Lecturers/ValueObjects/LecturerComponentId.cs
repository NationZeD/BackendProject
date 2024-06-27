using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;

public record LecturerComponentId(Guid Value) : BaseEntityId(Value);