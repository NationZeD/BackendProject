using BackendProject.App.Subjects.Entities;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Subjects.Repositories.IRepositories;

public interface ISubjectRepository : IBaseRepository<Subject, SubjectId>;