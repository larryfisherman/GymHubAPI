using GymHubAPI.Exceptions;
using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            HandleNotFoundException(context, ex);
        }
        catch (BadRequestException ex)
        {
            HandleBadRequestException(context, ex);
        }
        catch (Exception ex)
        {
            HandleGenericException(context, ex);
        }
    }


    private void HandleNotFoundException(HttpContext context, NotFoundException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorResponse { message = ex.Message };
        var json = JsonSerializer.Serialize(errorResponse);

        context.Response.WriteAsync(json);
    }

    private void HandleBadRequestException(HttpContext context, BadRequestException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorResponse { message = ex.Message };
        var json = JsonSerializer.Serialize(errorResponse);

        context.Response.WriteAsync(json);
    }

    private void HandleGenericException(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorResponse { message = "Something went wrong..." };
        var json = JsonSerializer.Serialize(errorResponse);

        context.Response.WriteAsync(json);
    }
}
