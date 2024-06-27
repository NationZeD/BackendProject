using BackendProject.App.Accounts.Customers.Dtos;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Customers.Repositories.IRepositories;

public interface ICustomerReadRepository : IRepository
{
    Task<CustomerDto> GetAsync(Guid id);
    Task<CustomerDto> GetByUserNameAsync(string username);
}