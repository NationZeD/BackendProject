using BackendProject.App.Accounts.Employees.BaseEmployee.Abstractions;
using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Edit;

public class UpdateBaseEmployeeCommandHandler<TRequest, TUpdateRequest, TId, TBaseEmployee> : IRequestHandler<TRequest>
    where TRequest : UpdateBaseEmployeeCommand<TUpdateRequest>
    where TBaseEmployee : BaseEmployee<TId>
    where TId : BaseEntityId
    where TUpdateRequest : IUpdateEmployeeRequest<TBaseEmployee, TId>
{
    private readonly IBaseEmployeeService<TBaseEmployee, TId> _entityService;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBaseEmployeeCommandHandler(IBaseEmployeeService<TBaseEmployee, TId> entityService,
        IUnitOfWork unitOfWork, IUserService userService)
    {
        _entityService = entityService;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entityRequest = request.Request;
        await _entityService.UpdateAsync(entityRequest);
        await _userService.ChangeUserNameAsync(entityRequest.Id.ToString(), $"Employee-{entityRequest.UserName}");
        await _unitOfWork.SaveAsync();
    }
}