using System.Data;
using BackendProject.App.Accounts.Customers.Dtos;
using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Accounts.Customers.Repositories;

public class CustomerReadRepository(ISqlConnectionFactory factory) : ICustomerReadRepository
{
    private const string Get = "GetCustomer";
    private const string GetByUserName = "GetCustomerByUserName";

    public async Task<CustomerDto> GetAsync(Guid id)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Id = id };

        return await connection.QueryFirstOrDefaultAsync<CustomerDto>
            (Get, parameters, commandType: CommandType.StoredProcedure);
    }
    
    public async Task<CustomerDto> GetByUserNameAsync(string username)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { UserName = username };

        return await connection.QueryFirstOrDefaultAsync<CustomerDto>
            (GetByUserName, parameters, commandType: CommandType.StoredProcedure);
    }
}