using Gomoku.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

using ValidationException = Gomoku.Pipeline.Handlers.ValidationException;

namespace Gomoku.Middleware
{
    public class ExceptionHandler
    {
        readonly RequestDelegate _Next;

        public ExceptionHandler(RequestDelegate next)
        {
            _Next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            using (var responseBodyMemoryStream = new MemoryStream())
            { 
                try
                {
                    await _Next(httpContext);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
            }
        }

        #region Exception Response Handler

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var statusCode = GetStatusCode(ex);

            var problem = new 
            {
                status = statusCode,
                title = GetTitle(ex),
                detail = ex.Message,
                errors = GetErrors(ex)
            };

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = statusCode;

            var result = JsonConvert.SerializeObject(problem, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(true, true)
                }
            });

            return httpContext.Response.WriteAsync(result);
        }

        private static int GetStatusCode(Exception ex) =>
        ex switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            ConflictException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        private static string GetTitle(Exception exception) =>
        exception switch
        {
            ValidationException => "Data Validation Error",
            ConflictException => "Domain Error",
            _ => "Server Error"
        };

        private static IDictionary<string, string[]> GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = null;
            if (exception is Gomoku.Pipeline.Handlers.ValidationException ex)
            {
                errors = ex.Errors;
            }
            return errors;
        }

        #endregion
    }
}
