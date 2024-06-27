using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

namespace BackendProject.App.Components.Commands.Delete;

public class DeleteComponentCommandHandler(IComponentService service, IUnitOfWork unitOfWork)
    : BaseLanguagedDeleteCommandHandler<Component, ComponentId, ComponentForm, ComponentDto, DeleteComponentCommand>
        (service, unitOfWork);