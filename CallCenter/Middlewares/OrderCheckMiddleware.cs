using CallCenter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CallCenter.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OrderCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public OrderCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IOrderService _orderService)
        {
            var orders = await _orderService.FindOrdersControllerCustom();
            foreach (var e in orders)
            {
                if (e.StartedAt.HasValue)
                {
                    if (e.StartedAt.Value.AddDays((double)e.Duration).CompareTo(DateTime.Now) < 0)
                    {
                        Console.WriteLine($"Order {e.Id} has expire");
                        e.Status = false;
                        await _orderService.Update(e);
                    }
                }
                
            }
            await _next(httpContext);
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OrderCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseOrderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OrderCheckMiddleware>();
        }
    }
}
