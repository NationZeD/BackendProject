using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetByLang;

namespace BackendProject.App.Components.Queries.GetByLang;

public class GetComponentByLangQuery(Guid id, string lang)
    : BaseLanguagedGetByLangQuery<Component, ComponentDto>(id, lang);