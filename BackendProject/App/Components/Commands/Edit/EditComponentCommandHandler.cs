using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.Components.Commands.Edit;

public class EditComponentCommandHandler(IComponentService service, IUnitOfWork unitOfWork)
    : BaseLanguagedEditCommandHandler<Component, ComponentId, ComponentForm, ComponentDto, EditComponentCommand>
        (service, unitOfWork);