using Microsoft.AspNetCore.Builder;

namespace Task1
{
    public static class UseMyMiddleware
    {
        public static IApplicationBuilder UseMyMw(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}