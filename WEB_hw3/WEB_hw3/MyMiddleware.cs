using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WEB_hw3
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
 
        public MyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            int angle = 30;
            double doubleAngle = Math.Pow(Math.Cos(angle), 2) - Math.Pow(Math.Sin(angle), 2);
            await context.Response.WriteAsync($"cos a = {doubleAngle}");
        }
    }
}