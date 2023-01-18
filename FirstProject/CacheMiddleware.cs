using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using logic_layer;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Hosting;
using System;
using entities;

namespace FirstProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CacheMiddleware
    {
        private readonly RequestDelegate _next;

        public CacheMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IlogicRating _service)
        {
            try
            {
               Rating r = new Rating();
               r.Host = httpContext.Request.Host.ToString();
               r.Method = httpContext.Request.Method.ToString();
	           r.Path = httpContext.Request.Path.ToString();
               r.Referer = httpContext.Request.RouteValues.ToString();
               r.UserAgent = httpContext.User.ToString();
               r.RecordDate = DateTime.Now;
	            await _service.addData(r);
	                
                await  _next(httpContext);

            }
            catch (Exception e)
            {
                throw new Exception("in middlware"+e.Message+ e.StackTrace);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CacheMiddlewareExtensions
    {
        public static IApplicationBuilder UseCacheMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CacheMiddleware>();
        }
    }
}
