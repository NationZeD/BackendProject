using System.Data;
using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Repositories.IRepositories;
using BackendProject.App.SystemFiles.Dtos;
using BackendProject.Shared.Persistence.SqlConnection;
using Dapper;

namespace BackendProject.App.Subjects.Repositories;

public class SubjectReadRepository(ISqlConnectionFactory factory) : ISubjectReadRepository
{
    private const string GetAll = "GetAllSubjects";
    private const string GetByIdByLang = "GetSubject";
    private const string GetAllSubjectComponents = "GetAllSubjectComponents";

    public async Task<List<SubjectDto>> GetAllAsync(string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { Lang = lang };
        var subjects =
            await connection.QueryAsync<SubjectDto, FileDto, SubjectDto>
            (GetAll, (subject, logoImage) =>
                {
                    subject.Image = logoImage;
                    return subject;
                },
                parameters,
                splitOn: "Id",
                commandType: CommandType.StoredProcedure);

        foreach (var subject in subjects)
        {
            var subjectParameters = new { Id = subject.Id };
            subject.SubjectComponents = [];
            
            var subjectComponents = (await connection.QueryAsync<SubjectComponentDto>
                (GetAllSubjectComponents, subjectParameters, commandType: CommandType.StoredProcedure)).ToList();
        
            subject.SubjectComponents.AddRange(subjectComponents);
        }
        
        return subjects.ToList();
    }

    public async Task<SubjectDto> GetByIdByLangAsync(Guid id, string lang)
    {
        using var connection = factory.CreateConnection();
        var parameters = new { SubjectId = id, Lang = lang };
        var query =
            (await connection.QueryAsync<SubjectDto, FileDto, SubjectDto>
            (GetByIdByLang, (subject, logoImage) =>
                {
                    subject.Image = logoImage;
                    return subject;
                },
                parameters,
                splitOn: "Id",
                commandType: CommandType.StoredProcedure)).FirstOrDefault();

        if (query == null)
            return null;
        
        var subjectParameters = new { Id = id };
        query.SubjectComponents = [];

        var subjectComponents = (await connection.QueryAsync<SubjectComponentDto>
            (GetAllSubjectComponents, subjectParameters, commandType: CommandType.StoredProcedure)).ToList();

        query.SubjectComponents.AddRange(subjectComponents);
        
        return query;
    }
}