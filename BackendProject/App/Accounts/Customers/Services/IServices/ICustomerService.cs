using BackendProject.App.Accounts.Customers.Commands.SignUp;
using BackendProject.App.Accounts.Customers.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Accounts.Customers.Services.IServices;

public interface ICustomerService : IAppService
{
    Task<CustomerId> CreateAsync(SignUpCustomerRequest request);
}