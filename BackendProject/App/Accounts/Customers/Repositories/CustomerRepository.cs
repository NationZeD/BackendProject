using BackendProject.App.Accounts.Customers.Entities;
using BackendProject.App.Accounts.Customers.Repositories.IRepositories;
using BackendProject.App.Accounts.Customers.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.App.Accounts.Customers.Repositories;

public class CustomerRepository : BaseRepository<Customer, CustomerId>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<bool> ExistsAsync(string username)
    {
        return await _db.Customers.AnyAsync(x =>
            x.PhoneNumber == username || x.Email == username);
    }

    public async Task<bool> ExistsAsync(string phoneNumber, string email)
    {
        return await _db.Customers.AnyAsync(x =>
            x.PhoneNumber == phoneNumber || x.Email == email);
    }
}