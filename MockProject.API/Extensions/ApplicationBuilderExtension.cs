using System.Net;
using System.Text;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using MockProject.API.Common;

namespace MockProject.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        throw exception;
                    }

                    var errors = validationException.Errors.Select(err => err.ErrorMessage);

                    var response = new ApiResponse()
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Errors = errors.ToList(),
                    };

                    var errorText = JsonSerializer.Serialize(response);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText, Encoding.UTF8);
                });
            });
        }
    }
}
