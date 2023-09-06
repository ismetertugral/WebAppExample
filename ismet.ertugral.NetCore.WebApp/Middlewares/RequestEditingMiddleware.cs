using Microsoft.AspNetCore.Http;

namespace WebApp.Middlewares
{
    public class RequestEditingMiddleware
    {
        RequestDelegate _requestDelegate;
        public RequestEditingMiddleware(RequestDelegate requestDelegate) 
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/test")
            {
                await context.Response.WriteAsync("Start Test");
            }
            else
            {
                await _requestDelegate(context);
            }
        }
    }
}
