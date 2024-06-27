using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Repositories.IRepositories;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.Components.Queries.GetByLang;

public class GetComponentByLangQueryHandler(IComponentReadRepository repo) : BaseLanguagedGetByLangQueryHandler
    <Component, ComponentId, ComponentDto, GetComponentByLangQuery>(repo);