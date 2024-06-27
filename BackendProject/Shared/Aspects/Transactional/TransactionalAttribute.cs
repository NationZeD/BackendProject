using BackendProject.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackendProject.Shared.Aspects.Transactional;

[AttributeUsage(AttributeTargets.Method)]
public class TransactionalAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var unitOfWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
        await unitOfWork.SaveAsync();
    }
}