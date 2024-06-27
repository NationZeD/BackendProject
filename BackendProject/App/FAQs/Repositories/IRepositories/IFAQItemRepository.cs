using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.FAQs.Repositories.IRepositories;

public interface IFAQItemRepository : IBaseRepository<FAQItem, FAQItemId>;