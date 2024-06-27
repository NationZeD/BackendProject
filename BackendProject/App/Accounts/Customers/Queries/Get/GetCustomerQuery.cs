using BackendProject.App.Accounts.Customers.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Queries.Get;

public class GetCustomerQuery(Guid id) : IRequest<CustomerDto>
{
    public Guid Id { get; set; } = id;
}