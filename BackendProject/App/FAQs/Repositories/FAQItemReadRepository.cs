using System.Data;
using BackendProject.App.FAQs.Dtos;
using BackendProject.App.FAQs.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.FAQs.Repositories;

public class FAQItemReadRepository(ISqlConnectionFactory factory) : IFAQItemReadRepository
{
    private const string GetAllByLang = "GetAllFAQs";
    private const string GetByIdByLang = "GetFAQ";

    public async Task<List<FAQItemDto>> GetAllAsync(string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang };
        var entity = await connection.QueryAsync<FAQItemDto>
            (GetAllByLang, parameters, commandType: CommandType.StoredProcedure);
        return entity.ToList();
    }

    public async Task<FAQItemDto> GetByIdByLangAsync(Guid id, string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang, Id = id };
        var entity = await connection.QueryFirstOrDefaultAsync<FAQItemDto>
            (GetByIdByLang, parameters, commandType: CommandType.StoredProcedure);
        return entity;
    }
}