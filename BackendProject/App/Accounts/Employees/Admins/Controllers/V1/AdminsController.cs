using BackendProject.App.Accounts.Employees.Admins.Commands.Create;
using BackendProject.App.Accounts.Employees.Admins.Commands.Delete;
using BackendProject.App.Accounts.Employees.Admins.Commands.Edit;
using BackendProject.App.Accounts.Employees.Admins.Dtos;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Admins.Queries.Get;
using BackendProject.App.Accounts.Employees.Admins.Queries.GetAll;
using BackendProject.App.Accounts.Employees.Admins.Queries.GetByUserName;
using BackendProject.App.Accounts.Employees.Admins.ValueObjects;
using BackendProject.App.Accounts.Employees.BaseEmployee.Controllers;
using BackendProject.App.Auth.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BackendProject.App.Accounts.Employees.Admins.Controllers.V1;

[Authorize(Roles = $"{Roles.Admin}")]
public class AdminsController : BaseEmployeeController<Admin, AdminId, AdminDto, CreateAdminRequest, UpdateAdminRequest>
{
    public AdminsController(IMediator mediator) : base(mediator)
    {
    }

    protected override async Task GenerateCreateAsync(CreateAdminRequest request)
    {
        await _mediator.Send(new CreateAdminCommand(request));
    }

    protected override async Task GenerateUpdateAsync(UpdateAdminRequest request)
    {
        await _mediator.Send(new UpdateAdminCommand(request));
    }

    protected override async Task GenerateDeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteAdminCommand(new AdminId(id)));
    }

    protected override async Task<AdminDto> GenerateGetAsync(Guid id)
    {
        return await _mediator.Send(new GetAdminQuery(id));
    }

    protected override async Task<AdminDto> GenerateGetByUserNameAsync(string username)
    {
        return await _mediator.Send(new GetAdminByUserNameQuery(username));
    }

    protected override async Task<List<AdminDto>> GenerateGetAllAsync()
    {
        return await _mediator.Send(new GetAllAdminsQuery());
    }
}