using BackendProject.App.Components.Entities;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Components.Repositories.IRepositories;

public interface IComponentRepository : IBaseRepository<Component, ComponentId>;