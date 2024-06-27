using System.Data;
using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Categories.Repositories;

public class CategoryReadRepository(ISqlConnectionFactory factory) : ICategoryReadRepository
{
    private const string GetAll = "GetAllCategories";
    private const string GetByIdByLang = "GetCategory";

    public async Task<List<CategoryDto>> GetAllAsync(string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang };
        var entity = await connection.QueryAsync<CategoryDto>
            (GetAll, parameters, commandType: CommandType.StoredProcedure);
        return entity.ToList();
    }

    public async Task<CategoryDto> GetByIdByLangAsync(Guid id, string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang, Id = id };
        var entity = await connection.QueryFirstOrDefaultAsync<CategoryDto>
            (GetByIdByLang, parameters, commandType: CommandType.StoredProcedure);
        return entity;
    }
}