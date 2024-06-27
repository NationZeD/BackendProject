using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Repositories.IRepositories;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Components.Repositories;

public class ComponentRepository(ApplicationDbContext db)
    : BaseRepository<Component, ComponentId>(db), IComponentRepository
{
    public override async Task<Component> GetAsync(ComponentId id)
    {
        return await _db.Components.Where(x => x.Id == id)
            .Include(x => x.Name).ThenInclude(x => x.Items)
            .AsSplitQuery().FirstOrDefaultAsync();
    }
}