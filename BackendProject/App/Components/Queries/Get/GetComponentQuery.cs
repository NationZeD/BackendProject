using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.Get;

namespace BackendProject.App.Components.Queries.Get;

public class GetComponentQuery(Guid id) : BaseLanguagedGetQuery<Component, ComponentForm>(id);