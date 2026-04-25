using Loans.Common;

namespace Loans.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = 500;

                var errorMessage = ex.InnerException?.Message ?? ex.Message;

                await context.Response.WriteAsJsonAsync(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = errorMessage
                    });
            }
        }
    }
}