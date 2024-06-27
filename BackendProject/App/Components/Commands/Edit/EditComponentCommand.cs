using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.Components.Commands.Edit;

public class EditComponentCommand(ComponentForm request)
    : BaseLanguagedEditCommand<Component, ComponentId, ComponentForm, ComponentDto>(request);