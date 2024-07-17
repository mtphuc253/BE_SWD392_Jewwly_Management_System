﻿namespace JewelleryShop.API.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("//////////GobalException//////////");
                Console.WriteLine(ex.Message);
                await context.Response.WriteAsync(ex.ToString());
            }
        }
    }
}
