using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using Sample.HelloWorld.Extensions; 

namespace Sample.HelloWorld.Middleware
{
    /// <summary>
    /// Middleware object to grab any unhandled exceptions
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next; 

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="next">The next request delegate to execute</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next; 
        }

        /// <summary>
        /// Function that executes when the middleware is called 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                if(httpContext.Response.StatusCode == StatusCodes.Status301MovedPermanently)
                {
                    return; 
                }

                await _next(httpContext); 
            }
            catch(Exception ex)
            {
                var user = httpContext.User.GetUserName(); 
                logger.LogError(ex, "Api Exception Occurred Path:{Path}, Username:{user}", httpContext.Request.Path, user);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync("Internal Server Error");
            }
        }
    }

}
