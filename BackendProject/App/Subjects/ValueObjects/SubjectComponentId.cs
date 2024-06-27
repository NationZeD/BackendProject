using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.ValueObjects;

public record SubjectComponentId(Guid Value) : BaseEntityId(Value);