using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

namespace BackendProject.App.Components.Queries.GetForm;

public class GetComponentFormQuery : BaseLanguagedGetFormQuery<Component, ComponentForm>;