using Microsoft.AspNetCore.Mvc.Filters;
using UnistreamTest2.Application.Exceptions;

namespace UnistreamTest2.Host.Filters;

public class ExceptionFilter : IExceptionFilter {
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(
        ILogger<ExceptionFilter> logger
    ) {
        _logger = logger;
    }

    public void OnException(ExceptionContext context) {
        switch (context.Exception) {
            case NotFoundException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case ConflictException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                break;
            default:
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(context.Exception, "");
                break;
        }

        context.HttpContext.Response.ContentType = "application/json";

        context.ExceptionHandled = true;
    }
}