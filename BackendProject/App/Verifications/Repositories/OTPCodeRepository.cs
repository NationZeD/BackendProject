using BackendProject.App.Verifications.Entities;
using BackendProject.App.Verifications.Repositories.IRepositories;
using BackendProject.App.Verifications.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Verifications.Repositories;

public class OTPCodeRepository : BaseRepository<OTPCode, OTPCodeId>, IOTPCodeRepository
{
    public OTPCodeRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<List<OTPCode>> GetAllBySourceAsync(string source)
    {
        return await _db.OTPCodes.Where(x => x.Source == source).ToListAsync();
    }
}