using BackendProject.Shared.Abstractions;

namespace BackendProject.App.AcademicYears.ValueObjects;

public record AcademicYearId(Guid Value) : BaseEntityId(Value);