using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Repositories.IRepositories;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.Components.Queries.GetAll;

public class GetAllComponentsQueryHandler(IComponentReadRepository repo)
    : BaseLanguagedGetAllQueryHandler<Component, ComponentId, ComponentDto, GetAllComponentsQuery>(repo);