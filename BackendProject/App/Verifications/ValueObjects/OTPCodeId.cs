using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Verifications.ValueObjects;

public record OTPCodeId(Guid Value) : BaseEntityId(Value);