using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyBasket_VerticalSlice.Middelwares
{
    public class ExceptionMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddelware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddelware(RequestDelegate next , ILogger<ExceptionMiddelware> logger , IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "somthing went Error", ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
               
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }


    }
}
