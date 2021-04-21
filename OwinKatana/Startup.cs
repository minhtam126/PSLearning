using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Owin;
using OwinKatana.Middlewares;

[assembly: OwinStartup(typeof(OwinKatana.Startup))]
namespace OwinKatana
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-startup-class-detection
    /// </summary>
    public class Startup
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOption
            {
                OnIncomingRequest = ctx =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Thread.Sleep(1000);
                    ctx.Items.Add("DebugStopWatch", stopWatch);
                },
                OnOutGoingRequest = ctx =>
                {
                    var stopwatch = (Stopwatch)ctx.Items["DebugStopWatch"];
                    stopwatch.Stop();
                    Console.WriteLine("Total time Elapse:" + stopwatch.ElapsedMilliseconds);
                }
            });
            
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Hello World.");
            });
        }
    }
}