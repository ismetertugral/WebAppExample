using System.Net;

namespace WebApp.Middlewares
{
    public class ResponseEditingMiddleware
    {
        RequestDelegate _requestDelegate;
        public ResponseEditingMiddleware(RequestDelegate requestDelegate) 
        { 
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            await _requestDelegate.Invoke(context);
            if (context.Response.StatusCode != StatusCodes.Status200OK)
            {
                await context.Response.WriteAsync($"Code: {context.Response.StatusCode} \nDescription: {((HttpStatusCode)context.Response.StatusCode).ToString()}");
            }
        }
    }
}
