using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OwinKatana.Middlewares
{
    public class DebugMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DebugMiddlewareOption _option;

        public DebugMiddleware(RequestDelegate next, DebugMiddlewareOption option)
        {
            _next = next;
            _option = option;

            if (_option.OnIncomingRequest == null)
            {
                _option.OnIncomingRequest = (ctx) =>
                {
                    Console.WriteLine("In coming request:" + ctx.Request.Path.ToString());
                };
            }
            if (_option.OnOutGoingRequest == null)
            {
                _option.OnOutGoingRequest = (ctx) =>
                {
                    Console.WriteLine("Outgoing request:" + ctx.Request.Path.ToString());
                };
            }
        }
        
        public async Task Invoke(HttpContext context)
        {
            _option.OnIncomingRequest(context);
            await _next(context);
            _option.OnOutGoingRequest(context);
        }
    }
}