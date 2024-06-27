using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.Components.Queries.Get;

public class GetComponentQueryHandler(IComponentService languagedCrudService)
    : BaseLanguagedGetQueryHandler<Component, ComponentId, ComponentForm, ComponentDto, GetComponentQuery>(languagedCrudService);