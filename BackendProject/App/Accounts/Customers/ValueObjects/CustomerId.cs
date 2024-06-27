using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Customers.ValueObjects;

public record CustomerId(Guid Value) : BaseEntityId(Value);