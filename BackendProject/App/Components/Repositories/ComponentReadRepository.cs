using System.Data;
using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Components.Repositories;

public class ComponentReadRepository(ISqlConnectionFactory factory) : IComponentReadRepository
{
    private const string GetAllByLang = "GetAllComponents";
    private const string GetByIdByLang = "GetComponent";

    public async Task<List<ComponentDto>> GetAllAsync(string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang };
        var entity = await connection.QueryAsync<ComponentDto>
            (GetAllByLang, parameters, commandType: CommandType.StoredProcedure);
        return entity.ToList();
    }

    public async Task<ComponentDto> GetByIdByLangAsync(Guid id, string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang, Id = id };
        var entity = await connection.QueryFirstOrDefaultAsync<ComponentDto>
            (GetByIdByLang, parameters, commandType: CommandType.StoredProcedure);
        return entity;
    }
}