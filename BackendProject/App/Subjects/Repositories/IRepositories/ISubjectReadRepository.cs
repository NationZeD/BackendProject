using BackendProject.App.Subjects.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Subjects.Repositories.IRepositories;

public interface ISubjectReadRepository : ILanguagedReadRepository<SubjectDto>;