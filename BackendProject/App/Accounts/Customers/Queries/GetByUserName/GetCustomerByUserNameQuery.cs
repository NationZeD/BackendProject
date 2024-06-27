using BackendProject.App.Accounts.Customers.Dtos;
using MediatR;

namespace BackendProject.App.Accounts.Customers.Queries.GetByUserName;

public class GetCustomerByUserNameQuery(string username) : IRequest<CustomerDto>
{
    public string UserName { get; set; } = username;
}