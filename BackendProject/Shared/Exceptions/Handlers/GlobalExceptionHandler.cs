using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace BackendProject.Shared.Exceptions.Handlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = "application/json; charset=utf-8";
        var data = ServiceResponse.FailedInstance(ex.Message);
        await context.Response.WriteAsync(JsonConvert.SerializeObject(data));
        return true;
    }
}