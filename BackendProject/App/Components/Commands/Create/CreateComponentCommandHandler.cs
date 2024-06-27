using BackendProject.App.Components.Dtos;
using BackendProject.App.Components.Entities;
using BackendProject.App.Components.Services.IServices;
using BackendProject.App.Components.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

namespace BackendProject.App.Components.Commands.Create;

public class CreateComponentCommandHandler(IComponentService service, IUnitOfWork unitOfWork)
    : BaseLanguagedCreateCommandHandler<Component, ComponentId, ComponentForm, ComponentDto
        , CreateComponentCommand>(service, unitOfWork);