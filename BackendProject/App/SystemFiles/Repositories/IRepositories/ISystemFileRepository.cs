using BackendProject.App.SystemFiles.Entities;
using BackendProject.App.SystemFiles.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.SystemFiles.Repositories.IRepositories;

public interface ISystemFileRepository : IBaseRepository<SystemFile, SystemFileId>;