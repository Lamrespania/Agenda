namespace Agenda.Api;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
{
    private readonly ILogger<ExceptionMiddleware> _logger = logger;
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = 500;
#if DEBUG
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
#else
            await context.Response.WriteAsJsonAsync(new { error = "Internal error" });
#endif
        }
    }
}