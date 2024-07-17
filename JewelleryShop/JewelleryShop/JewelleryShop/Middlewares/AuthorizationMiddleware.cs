using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace JewelleryShop.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStaffService _staffService;

        public AuthorizationMiddleware(RequestDelegate next, IStaffService staffService)
        {
            _next = next;
            _staffService = staffService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!IsAuthorized(context))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            try
            {
                var user = await GetUser(context);
                if (user == null) throw new Exception("User does not exist.");
                if (IsUserActive(user)) throw new Exception("User Account Is Disabled.");

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: " + ex.Message);
            }
        }

        private bool IsAuthorized(HttpContext context)
        {
            return context.Request.Headers.ContainsKey("Authorization") &&
              context.Request.Headers["Authorization"].ToString().StartsWith("Bearer ");
        }

        private string GetToken(HttpContext context)
        {
            return context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }

        private async Task<StaffCommonDTO?> GetUser(HttpContext context)
        {
            if (IsAuthorized(context))
            {
                var token = GetToken(context);

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                var ID = jwtToken?.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
                if (ID != null) return null;

                var user = await _staffService.GetStaffById(ID);
                return user;
            }

            return null;
        }
        private bool IsUserActive(StaffCommonDTO staffData)
        {
            return staffData.Status.ToLower() == "active";
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
