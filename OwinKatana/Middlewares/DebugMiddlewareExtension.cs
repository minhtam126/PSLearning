using Microsoft.AspNetCore.Builder;

namespace OwinKatana.Middlewares
{
    public static class DebugMiddlewareExtension
    {
        public static void UseDebugMiddleware(this IApplicationBuilder app, DebugMiddlewareOption option = null)
        {
            option ??= new DebugMiddlewareOption();

            app.UseMiddleware<DebugMiddleware>(option);
        }
    }
}