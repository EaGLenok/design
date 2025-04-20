using System.Net;
using System.Text.Json;
using FluentValidation;
using LibraryDesignKey.Shared.Exceptions;
using Microsoft.AspNetCore.Http;

namespace LibraryDesignKey.Api.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException vex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                error = "Validation failed",
                details = vex.Errors.Select(e => e.ErrorMessage)
            });
            await context.Response.WriteAsync(result);
        }
        catch (KeyNotFoundException knf)
        {
            context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                error = knf.Message
            });
            await context.Response.WriteAsync(result);
        }
        catch (DuplicateEntityException dex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Conflict;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                error = dex.Message
            });
            await context.Response.WriteAsync(result);
        }
        catch (InvalidOperationException iox)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                error = iox.Message
            });
            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                error = "An unexpected error occurred",
                details = ex.Message
            });
            await context.Response.WriteAsync(result);
        }
    }
}
