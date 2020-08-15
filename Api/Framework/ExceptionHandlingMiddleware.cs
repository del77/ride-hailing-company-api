using System;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shared;

namespace Api.Framework
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, context);
                throw;
            }
        }

        private Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var statusCode = exception switch
            {
                ConcurrencyException _ => HttpStatusCode.Conflict,
                ResourceDoesNotExistException _ => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            var errorCode = exception is RideHailingException hailingException
                ? hailingException.Code
                : "Something went wrong. Please try again or contact administrator.";

            var response = new
            {
                code = errorCode
            };

            var result = JsonConvert.SerializeObject(response);
            context.Request.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}