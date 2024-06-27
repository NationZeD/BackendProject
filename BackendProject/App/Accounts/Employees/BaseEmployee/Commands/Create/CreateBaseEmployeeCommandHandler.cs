using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;

public class CreateBaseEmployeeCommandHandler<TRequest, TCreateRequest, TId, TBaseEmployee> : IRequestHandler<TRequest>
    where TRequest : CreateBaseEmployeeCommand<TCreateRequest>
    where TBaseEmployee : BaseEmployee<TId>
    where TId : BaseEntityId
    where TCreateRequest : ICreateEmployeeRequest<TBaseEmployee, TId>
{
    private readonly IBaseEmployeeService<TBaseEmployee, TId> _entityService;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _role;

    public CreateBaseEmployeeCommandHandler(IBaseEmployeeService<TBaseEmployee, TId> entityService,
        IUserService userService, IUnitOfWork unitOfWork, string role)
    {
        _entityService = entityService;
        _userService = userService;
        _unitOfWork = unitOfWork;
        _role = role;
    }


    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entityRequest = request.Request;

        var entityId = await _entityService.CreateAsync(entityRequest);

        await _userService.CreateAsync(entityId.Value.ToString(), $"Employee-{request.Request.UserName}");

        await _userService.ChangePasswordAsync(entityId.Value.ToString(), request.Request.Password);

        await _userService.AddToRoleAsync(entityId.Value.ToString(), _role);

        await _unitOfWork.SaveAsync();
    }
}