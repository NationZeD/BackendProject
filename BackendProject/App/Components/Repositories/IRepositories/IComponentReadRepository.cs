using BackendProject.App.Components.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Components.Repositories.IRepositories;

public interface IComponentReadRepository : ILanguagedReadRepository<ComponentDto>;