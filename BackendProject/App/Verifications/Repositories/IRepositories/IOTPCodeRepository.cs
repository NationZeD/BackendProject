using BackendProject.App.Verifications.Entities;
using BackendProject.App.Verifications.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Verifications.Repositories.IRepositories;

public interface IOTPCodeRepository : IBaseRepository<OTPCode, OTPCodeId>
{
    Task<List<OTPCode>> GetAllBySourceAsync(string source);
}