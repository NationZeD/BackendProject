using BackendProject.App.SystemFiles.Entities;
using BackendProject.App.SystemFiles.Repositories.IRepositories;
using BackendProject.App.SystemFiles.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;

namespace BackendProject.App.SystemFiles.Repositories;

public class SystemFileRepository(ApplicationDbContext db)
    : BaseRepository<SystemFile, SystemFileId>(db), ISystemFileRepository;