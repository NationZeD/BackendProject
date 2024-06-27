using BackendProject.App.Accounts.Customers.Entities;
using BackendProject.App.Accounts.Customers.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Customers.Repositories.IRepositories;

public interface ICustomerRepository : IBaseRepository<Customer, CustomerId>
{
    Task<bool> ExistsAsync(string username);
    
    Task<bool> ExistsAsync(string phoneNumber, string email);
}