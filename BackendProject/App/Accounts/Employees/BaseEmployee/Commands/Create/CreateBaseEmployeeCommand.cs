using MediatR;

namespace BackendProject.App.Accounts.Employees.BaseEmployee.Commands.Create;

public abstract class CreateBaseEmployeeCommand<TRequest> : IRequest
{
    public TRequest Request { get; private set; }

    protected CreateBaseEmployeeCommand(TRequest request)
    {
        Request = request;
    }
}
