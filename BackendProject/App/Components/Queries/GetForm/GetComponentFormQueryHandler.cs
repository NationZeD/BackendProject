using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.Components.Queries.GetForm;

public class GetComponentFormQueryHandler(IComponentService languagedCrudService) : BaseLanguagedGetFormQueryHandler
    <Component, ComponentId, ComponentForm, ComponentDto, GetComponentFormQuery>(languagedCrudService);