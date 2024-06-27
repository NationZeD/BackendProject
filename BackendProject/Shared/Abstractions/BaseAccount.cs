namespace BackendProject.Shared.Abstractions;

public abstract class BaseAccount<TEntityId> : BaseEntity<TEntityId> where TEntityId : BaseEntityId
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public BaseAccount()
    {
        
    }
    protected BaseAccount(TEntityId id) : base(id)
    {
    }

    protected BaseAccount(TEntityId id, string? firstName, string? lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}