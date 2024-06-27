using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.Components.Commands.Delete;

public class DeleteComponentCommand(ComponentId id)
    : BaseLanguagedDeleteCommand<Component, ComponentId, ComponentForm, ComponentDto>(id);