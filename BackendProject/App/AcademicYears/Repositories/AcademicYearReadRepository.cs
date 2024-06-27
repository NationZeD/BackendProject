using System.Data;
using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Repositories.IRepositories;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.AcademicYears.Repositories;

public class AcademicYearReadRepository : IAcademicYearReadRepository
{
    private const string GetAll = "GetAllAcademicYears";
    private const string Get = "GetAcademicYear";

    private readonly ISqlConnectionFactory _factory;

    public AcademicYearReadRepository(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<AcademicYearDto> GetAsync(Guid id)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { Id = id };

        return await connection.QueryFirstOrDefaultAsync<AcademicYearDto>
            (Get, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<AcademicYearDto>> GetAllAsync()
    {
        using var connection = _factory.CreateConnection();
        var entity = await connection.QueryAsync<AcademicYearDto>
            (GetAll, commandType: CommandType.StoredProcedure);

        return entity.ToList();
    }
}