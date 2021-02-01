using Microsoft.AspNetCore.Builder;

namespace BlogPost.WebAPI.Middleware.Extensions
{
    public static class ErrorWrappingExtentios
    {
        public static IApplicationBuilder UseErrorWrapping(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}
