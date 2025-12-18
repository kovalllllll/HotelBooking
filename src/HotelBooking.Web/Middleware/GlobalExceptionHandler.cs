using System.Net;
using HotelBooking.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Web.Middleware;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment environment)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var traceId = httpContext.TraceIdentifier;

        var (statusCode, errorCode, title, errors) = MapException(exception);

        LogException(exception, statusCode, traceId);

        var detail = statusCode >= 500 && !environment.IsDevelopment()
            ? "An unexpected error occurred. Please try again later."
            : exception.Message;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = GetErrorTypeUri(statusCode),
            Instance = httpContext.Request.Path,
            Detail = detail,
            Extensions =
            {
                ["traceId"] = traceId,
                ["errorCode"] = errorCode
            }
        };

        if (errors is { Count: > 0 })
        {
            problemDetails.Extensions["errors"] = errors;
        }

        if (environment.IsDevelopment() && statusCode >= 500)
        {
            problemDetails.Extensions["exception"] = new
            {
                message = exception.Message,
                type = exception.GetType().Name,
                stackTrace = exception.StackTrace
            };
        }

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/problem+json";

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private (int StatusCode, string ErrorCode, string Title, IDictionary<string, string[]>? Errors) MapException(
        Exception exception)
    {
        return exception switch
        {
            ValidationException validationEx => (
                validationEx.StatusCode,
                validationEx.ErrorCode,
                "Validation Error",
                validationEx.Errors.Count > 0 ? validationEx.Errors : null),

            NotFoundException notFoundEx => (
                notFoundEx.StatusCode,
                notFoundEx.ErrorCode,
                "Not Found",
                null),

            UnauthorizedException unauthorizedEx => (
                unauthorizedEx.StatusCode,
                unauthorizedEx.ErrorCode,
                "Unauthorized",
                null),

            ForbiddenException forbiddenEx => (
                forbiddenEx.StatusCode,
                forbiddenEx.ErrorCode,
                "Forbidden",
                null),

            ConflictException conflictEx => (
                conflictEx.StatusCode,
                conflictEx.ErrorCode,
                "Conflict",
                null),

            AppException appEx => (
                appEx.StatusCode,
                appEx.ErrorCode,
                "Application Error",
                null),

            _ => (
                (int)HttpStatusCode.InternalServerError,
                "INTERNAL_ERROR",
                "Internal Server Error",
                null)
        };
    }

    private void LogException(Exception exception, int statusCode, string traceId)
    {
        if (statusCode >= 500)
        {
            logger.LogError(exception,
                "Серверна помилка. TraceId: {TraceId}, Message: {Message}",
                traceId, exception.Message);
        }
        else
        {
            logger.LogWarning(
                "Клієнтська помилка. TraceId: {TraceId}, StatusCode: {StatusCode}, Message: {Message}",
                traceId, statusCode, exception.Message);
        }
    }

    private static string GetErrorTypeUri(int statusCode)
    {
        return statusCode switch
        {
            400 => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            401 => "https://tools.ietf.org/html/rfc7235#section-3.1",
            403 => "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            404 => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            409 => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };
    }
}