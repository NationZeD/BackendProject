using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Components.Services.IServices;

public interface IComponentService : ILanguagedCrudService<Component, ComponentId, ComponentForm, ComponentDto>;