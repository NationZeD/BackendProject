using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.Repositories.IRepositories;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.FAQs.Repositories;

public class FAQItemRepository(ApplicationDbContext db) : BaseRepository<FAQItem, FAQItemId>(db), IFAQItemRepository
{
    public override async Task<FAQItem> GetAsync(FAQItemId id)
    {
        return await _db.FAQItems.Where(x => x.Id == id)
            .Include(x => x.Question).ThenInclude(x => x.Items)
            .Include(x => x.Answer).ThenInclude(x => x.Items)
            .AsSplitQuery().FirstOrDefaultAsync();
    }
}