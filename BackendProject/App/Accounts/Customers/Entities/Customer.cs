using BackendProject.App.Accounts.Customers.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Customers.Entities;

public class Customer : BaseAccount<CustomerId>
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Customer()
    {
    }

    private Customer(string phoneNumber, string email, string firstName, string lastName)
        : base(new CustomerId(Guid.NewGuid()), firstName, lastName)
    {
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public static Customer Create(string phoneNumber, string email, string firstName, string lastName)
    {
        return new Customer(phoneNumber, email, firstName, lastName);
    }
}