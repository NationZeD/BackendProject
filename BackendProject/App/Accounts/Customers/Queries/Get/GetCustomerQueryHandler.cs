using BackendProject.App.Accounts.Customers.Dtos;
using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.Shared.Exceptions;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Queries.Get;

public class GetCustomerQueryHandler(ICustomerReadRepository repository)
    : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetAsync(request.Id);
        if (customer == null)
            throw new NotFoundException("Customer");

        return customer;
    }
}