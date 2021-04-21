using System;
using Microsoft.AspNetCore.Http;

namespace OwinKatana.Middlewares
{
    public class DebugMiddlewareOption
    {
        public Action<HttpContext> OnIncomingRequest { get; set; }
        public Action<HttpContext> OnOutGoingRequest { get; set; }
    }
}