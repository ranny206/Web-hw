using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_Routing
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value;
            if (path == "/Task1")
            {
                await context.Response.WriteAsync("Hello world");
            }
            else if (path == "/Task2")
            {
                await context.Response.WriteAsync("Formula1");
            }
            else if (path == "/Task3")
            {
                await context.Response.WriteAsync("Formula2");
            }
            else if (path == "/Task4")
            {
                await context.Response.WriteAsync("Formula3");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
            //await _next.Invoke(context);
        }
    }
}