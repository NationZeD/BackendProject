using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Employees.Admins.ValueObjects;

public record AdminId : BaseEntityId
{
    public AdminId()
    {
    }

    public AdminId(Guid Value) : base(Value)
    {
    }

    public static AdminId New => new AdminId(Guid.NewGuid());
}