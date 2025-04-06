using System.Net;
using Core.ErrorModel;
using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError => appError.Run(async context =>
        {
            context.Response.ContentType = "application/json";
            
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (contextFeature != null)
            {
                context.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    InvalidCredentialsException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };
                
                await context.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = contextFeature.Error.Message
                }.ToString());
            }
        }));
    }

}