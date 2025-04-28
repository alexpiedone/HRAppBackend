using HRApp.Domain;
using System.Diagnostics;
using System.Text.Json;

namespace HRApp.Api;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            await _next(context);
            var elapsedMs = (DateTime.UtcNow - startTime).TotalMilliseconds;
            
            _logger.LogInformation(
                "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                elapsedMs);
        }
        catch (Exception ex)
        {
            var elapsedMs = (DateTime.UtcNow - startTime).TotalMilliseconds;
            _logger.LogError(ex,
                "HTTP {Method} {Path} failed with exception after {ElapsedMs}ms",
                context.Request.Method,
                context.Request.Path,
                elapsedMs);
            
            throw;
        }
    }
}

