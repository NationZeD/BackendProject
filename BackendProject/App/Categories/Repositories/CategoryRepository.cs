using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Repositories.IRepositories;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Categories.Repositories;

public class CategoryRepository(ApplicationDbContext db) : BaseRepository<Category, CategoryId>(db), ICategoryRepository
{
    public override async Task<Category> GetAsync(CategoryId id)
    {
        var result = await _db.Categories.Where(x => x.Id == id)
            .Include(x => x.Name).ThenInclude(x => x.Items)
            .AsSplitQuery().FirstOrDefaultAsync();
        return result;
    }
}