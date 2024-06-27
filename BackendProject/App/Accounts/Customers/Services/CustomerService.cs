using BackendProject.App.Accounts.Customers.Commands.SignUp;
using BackendProject.App.Accounts.Customers.Entities;
using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.App.Accounts.Customers.Services.IServices;
using BackendProject.App.Accounts.Customers.ValueObjects;
using BackendProject.Shared.Exceptions;

namespace BackendProject.App.Accounts.Customers.Services;

public class CustomerService(ICustomerRepository customerRepo) : ICustomerService
{
    public async Task<CustomerId> CreateAsync(SignUpCustomerRequest request)
    {
        if (await customerRepo.ExistsAsync(request.PhoneNumber, request.Email))
            throw new DuplicateInstanceException("Customer");

        var customer = Customer.Create(request.PhoneNumber, request.Email, request.FirstName, request.LastName);

        await customerRepo.CreateAsync(customer);

        return customer.Id;
    }
}