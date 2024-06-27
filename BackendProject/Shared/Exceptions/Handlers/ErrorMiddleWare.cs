using Newtonsoft.Json;

namespace BackendProject.Shared.Exceptions.Handlers;

public class ErrorMiddleWare
{
    private readonly RequestDelegate _next;

    public ErrorMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = "application/json; charset=utf-8";
        var data = ServiceResponse.FailedInstance(ex.Message);
        await context.Response.WriteAsync(JsonConvert.SerializeObject(data));
    }
}