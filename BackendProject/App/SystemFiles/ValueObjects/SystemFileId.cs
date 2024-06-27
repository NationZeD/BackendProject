using BackendProject.Shared.Abstractions;

namespace BackendProject.App.SystemFiles.ValueObjects;

public record SystemFileId(Guid Value) : BaseEntityId(Value);