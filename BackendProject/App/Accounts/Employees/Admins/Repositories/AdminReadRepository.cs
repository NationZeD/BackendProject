using System.Data;
using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Accounts.Employees.Admins.Repositories;

public class AdminReadRepository : IAdminReadRepository
{
    private readonly ISqlConnectionFactory _factory;

    public AdminReadRepository(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }
    
    private const string Get = "GetAdmin";
    private const string GetAll = "GetAllAdmins";
    private const string GetByUserName = "GetAdminByUserName";

    public async Task<AdminDto> GetAsync(Guid id)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { Id = id };

        return await connection.QueryFirstOrDefaultAsync<AdminDto>
            (Get, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<AdminDto> GetByUserNameAsync(string username)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { UserName = username };

        return await connection.QueryFirstOrDefaultAsync<AdminDto>
            (GetByUserName, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<AdminDto>> GetAllAsync()
    {
        using var connection = _factory.CreateConnection();
        var entity = await connection.QueryAsync<AdminDto>
            (GetAll, commandType: CommandType.StoredProcedure);

        return entity.ToList();
    }
}