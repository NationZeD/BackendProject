using BackendProject.App.Accounts.Customers.Dtos;
using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.Shared.Exceptions;
using BackendProject.Shared.Extensions;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Queries.GetByUserName;

public class GetCustomerByUserNameQueryHandler(ICustomerReadRepository repository)
    : IRequestHandler<GetCustomerByUserNameQuery, CustomerDto>
{
    public async Task<CustomerDto> Handle(GetCustomerByUserNameQuery request, CancellationToken cancellationToken)
    {
        request.UserName = request.UserName.ToNormalizedPhoneNumber();
        
        var customer = await repository.GetByUserNameAsync(request.UserName);
        if (customer == null)
            throw new NotFoundException("Customer");

        return customer;
    }
}