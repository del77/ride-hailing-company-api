using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
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
            var errorCode = exception is RideHailingException hailingException 
                ? hailingException.Code
                : "error";
            var statusCode = HttpStatusCode.BadRequest;

            if (exception is ConcurrencyException)
                statusCode = HttpStatusCode.Conflict;

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