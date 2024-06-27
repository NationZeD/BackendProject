using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.Components.Commands.Create;

public class CreateComponentCommand(ComponentForm request)
    : BaseLanguagedCreateCommand<Component, ComponentId, ComponentForm, ComponentDto>(request);