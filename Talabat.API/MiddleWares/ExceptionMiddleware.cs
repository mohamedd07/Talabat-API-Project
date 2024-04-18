﻿using System.Text.Json;
using Talabat.API.Errors;

namespace Talabat.API.MiddleWares
{
    public class ExceptionMiddleware : IMiddleware
    {
        //private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(/*RequestDelegate next,*/ ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            //_next = next;
            _logger = logger;
            _env = env;
        }
        //public async Task InvokeAsync(HttpContext context)
        //{
        //    try
        //    {
        //        await _next.Invoke(context); // Go To The Next Middlrware
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        context.Response.StatusCode = 500;
        //        context.Response.ContentType = "application/json";

        //        var response = _env.IsDevelopment() ? new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString())
        //            :
        //            new ApiExceptionResponse(500);

        //        var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        //        var json = JsonSerializer.Serialize(response, options);

        //        await context.Response.WriteAsync(json);
        //    }
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
        {
            try
            {
                await _next.Invoke(context); // Go To The Next Middlrware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = _env.IsDevelopment() ? new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString())
                    :
                    new ApiExceptionResponse(500);

                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
