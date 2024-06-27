using BackendProject.App.Accounts.Employees.BaseEmployee.Entities;
using BackendProject.App.Accounts.Employees.BaseEmployee.Services.IServices;
using BackendProject.App.Auth.Services.IServices;
using BackendProject.Shared.Abstractions;
using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Delete;

public class DeleteBaseEmployeeCommandHandler<TCommand,TId, TBaseEmployee> : IRequestHandler<TCommand>
    where TCommand: DeleteBaseEmployeeCommand<TId>
    where TId : BaseEntityId
    where TBaseEmployee : BaseEmployee<TId>
{
    private readonly IBaseEmployeeService<TBaseEmployee, TId> _entityService;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBaseEmployeeCommandHandler(
        IBaseEmployeeService<TBaseEmployee, TId> entityService,
        IUserService userService,
        IUnitOfWork unitOfWork)
    {
        _entityService = entityService;
        _userService = userService;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(TCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _entityService.DeleteAsync(id);
        await _userService.DeleteAsync(id.Value.ToString());
        await _unitOfWork.SaveAsync();
    }
}