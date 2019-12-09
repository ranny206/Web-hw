using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_Error_Routing_Auth
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
            var path = context.Request.Path.Value;
            switch (path)
            {
                case "/Task1":
                    await context.Response.WriteAsync("Hello world");
                    break;
                case "/Task2":
                    await context.Response.WriteAsync("Formula1");
                    break;
                case "/Task3":
                    await context.Response.WriteAsync("Formula2");
                    break;
                case "/Task4":
                    await context.Response.WriteAsync("Formula3");
                    break;
                default:
                    context.Response.StatusCode = 404;
                    break;
            }

            //await _next.Invoke(context);
        } 
    }
}