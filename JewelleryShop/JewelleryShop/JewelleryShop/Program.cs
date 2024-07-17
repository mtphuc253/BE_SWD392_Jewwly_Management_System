using JewelleryShop.API;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.Business.Service;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using JewelleryShop.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using JewelleryShop.API.Middlewares;

namespace JewelleryShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddWebAPIService();
            builder.Services.AddDbContext<JewelleryDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
                .LogTo(Console.WriteLine, LogLevel.Information);
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            var app = builder.Build();
            app.AddWebApplicationMiddleware();
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseMiddleware<AuthorizationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
