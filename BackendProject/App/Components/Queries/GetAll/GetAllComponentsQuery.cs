using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetAll;

namespace BackendProject.App.Components.Queries.GetAll;

public class GetAllComponentsQuery(string lang) : BaseLanguagedGetAllQuery<Component, ComponentDto>(lang);