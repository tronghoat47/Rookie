using Assignment_MiddleWare.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;


        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Request request = GetDataFromRequest(httpContext.Request);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Schema: {request.Schema}");
            sb.AppendLine($"Host: {request.Host}");
            sb.AppendLine($"Path: {request.Path}");
            sb.AppendLine($"QueryString: {request.QueryString}");
            sb.AppendLine($"RequestBody: {request.RequestBody}");

            Log.Information(sb.ToString());
            return _next(httpContext);
        }

        private Request GetDataFromRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var body = new StreamReader(request.Body).ReadToEndAsync();
            var rawMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(body.Result))
            {
                rawMessage = "No Request Body";
            }
            else
            {
                var reader = new StreamReader(request.Body);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                rawMessage = reader.ReadToEnd();
            }
            request.Body.Position = 0;

            return new Request()
            {
                Schema = request.Scheme,
                Host = request.Host.Value,
                Path = request.Path,
                QueryString = request.QueryString.Value,
                RequestBody = rawMessage
            };
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
