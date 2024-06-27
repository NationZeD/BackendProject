using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.Services.IServices;

public interface ISubjectService : IAppService
{
    Task CreateAsync(SubjectForm request);
    Task<SubjectForm> GetForm();
    Task UpdateAsync(SubjectForm form);
    Task<SubjectForm> GetAsync(SubjectId id);
}