using BackendProject.App.Subjects.Entities;
using BackendProject.App.Subjects.Repositories.IRepositories;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Subjects.Repositories;

public class SubjectRepository(ApplicationDbContext db) : BaseRepository<Subject, SubjectId>(db), ISubjectRepository
{
    public override async Task<Subject> GetAsync(SubjectId id)
    {
        return await _db.Subjects.Where(x => x.Id == id)
            .Include(x => x.Name).ThenInclude(x => x.Items)
            .Include(x => x.SubjectComponents)
            .AsSplitQuery().FirstOrDefaultAsync();
    }
}