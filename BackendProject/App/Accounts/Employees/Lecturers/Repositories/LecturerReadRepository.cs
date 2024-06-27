using System.Data;
using BackendProject.App.Accounts.Employees.Lecturers.Dtos;
using BackendProject.App.Accounts.Employees.Lecturers.Queries.Filter;
using BackendProject.App.Accounts.Employees.Lecturers.Repositories.IRepositories;
using BackendProject.App.Components.Dtos;
using BackendProject.Shared.Paging;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Accounts.Employees.Lecturers.Repositories;

public class LecturerReadRepository : ILecturerReadRepository
{
    private readonly ISqlConnectionFactory _factory;

    public LecturerReadRepository(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    private const string Get = "GetLecturer";
    private const string GetById = "GetLecturerById";
    private const string GetByUserName = "GetLecturerByUserName";
    private const string GetAllLecturerComponents = "GetAllLecturerComponents";
    private const string GetAllByLang = "GetAllLecturersByLang";
    private const string GetAll = "GetAllLecturers";
    private const string FilterLecturers = "FilterLecturers";
    private const string FilterLecturersCount = "FilterLecturersCount";

    public async Task<LecturerDto> GetAsync(Guid id, string lang)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { Id = id };

        var query = await connection.QueryFirstOrDefaultAsync<LecturerDto>
            (Get, parameters, commandType: CommandType.StoredProcedure);

        if (query == null)
            return null;

        query.Components = [];

        var componentParameters = new { Id = id, Lang = lang };

        var lecturerComponents = (await connection.QueryAsync<ComponentDto>
            (GetAllLecturerComponents, componentParameters, commandType: CommandType.StoredProcedure)).ToList();

        query.Components.AddRange(lecturerComponents);
        return query;
    }

    public async Task<LecturerDto> GetAsync(Guid id)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { Id = id };

        return await connection.QueryFirstOrDefaultAsync<LecturerDto>
            (GetById, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<LecturerDto> GetByUserNameAsync(string username)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { UserName = username };

        return await connection.QueryFirstOrDefaultAsync<LecturerDto>
            (GetByUserName, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<LecturerDto>> GetAllAsync()
    {
        using var connection = _factory.CreateConnection();
        var entity = await connection.QueryAsync<LecturerDto>
            (GetAll, commandType: CommandType.StoredProcedure);

        return entity.ToList();
    }

    public async Task<PagedList<LecturerDto>> FilterAsync(LecturerPagingQuery query)
    {
        using var connection = _factory.CreateConnection();
        var text = query.SearchText ?? "";
        var parameters = new
        {
            SearchText = text,
            Skip = (query.PageIndex - 1) * query.PageSize,
            Take = query.PageSize,
            OrderByField = query.SortField,
            SortOrder = query.SortOrder == 1 ? "asc" : "desc",
            Lang = query.Lang
        };

        var filterCountResult = await connection.QueryAsync<int>
            (FilterLecturersCount, parameters, commandType: CommandType.StoredProcedure);
        var count = filterCountResult.First();

        var lookup = new Dictionary<Guid, LecturerDto>();

        await connection.QueryAsync<LecturerDto, ComponentDto, LecturerDto>
        (FilterLecturers, (lecturer, component) =>
        {
            if (!lookup.TryGetValue(lecturer.Id, out var existing))
            {
                existing = lecturer;
                existing.Components = new();
                lookup.Add(lecturer.Id, lecturer);
            }

            if (component != null)
                existing.Components.Add(component);


            return lecturer;
        }, parameters, commandType: CommandType.StoredProcedure, splitOn: "Id");
        return new PagedList<LecturerDto>(lookup.Select(x => x.Value).ToList(), count, query.PageIndex, query.PageSize);
    }

    public async Task<List<LecturerDto>> GetAllAsync(string lang)
    {
        using var connection = _factory.CreateConnection();
        var parameters = new { Lang = lang };
        
        var lookup = new Dictionary<Guid, LecturerDto>();

        await connection.QueryAsync<LecturerDto, ComponentDto, LecturerDto>
        (GetAllByLang, (lecturer, component) =>
        {
            if (!lookup.TryGetValue(lecturer.Id, out var existing))
            {
                existing = lecturer;
                existing.Components = new();
                lookup.Add(lecturer.Id, lecturer);
            }

            if (component != null)
                existing.Components.Add(component);


            return lecturer;
        }, parameters, commandType: CommandType.StoredProcedure, splitOn: "Id");
        return lookup.Select(x => x.Value).ToList();
    }
}