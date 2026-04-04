using System.Net;
using System.Text.Json;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DestinationNotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;

            var response = new
            {
                StatusCode = 500,
                Message = "Internal Server Error"
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}