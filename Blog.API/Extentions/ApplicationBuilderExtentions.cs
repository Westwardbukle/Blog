using BlogCommon.Error;
using BlogCommon.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BlogAPI.Extentions;

public static class ApplicationBuilderExtentions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        /*BadRequestException => StatusCodes.Status400BadRequest,
                        PermissionDeniedException => StatusCodes.Status403Forbidden,*/
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}