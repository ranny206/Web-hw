using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_Error_Routing_Auth
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            switch (context.Response.StatusCode)
            {
                case 403:
                    await context.Response.WriteAsync("Access Denied");
                    break;
                case 404:
                    await context.Response.WriteAsync("Not Found");
                    break;
            }
        }
    }
}