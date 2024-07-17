using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Repository.Interface;
using JewelleryShop.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JewelleryShop.API.Middlewares;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace JewelleryShop.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IWarrantyRepository, WarrantyRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ICustomerPromotionRepository, CustomerPromotionRepository>();
            services.AddScoped<IStaffStationRepository, StaffStationRepository>();
            services.AddScoped<IRewardsProgramRepository, RewardsProgramRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IGemstoneRepository, GemstoneRepository>();
            services.AddScoped<IItemImageRepository, ItemImageRepository>();
            services.AddScoped<IReturnPolicyRepository, ReturnPolicyRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IWarrantyService, WarrantyService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<ICustomerPromotionService, CustomerPromotionService>();
            services.AddScoped<IStaffStationService, StaffStationService>();
            services.AddScoped<IRewardsProgramService, RewardsProgramService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<IGemstoneService, GemstoneService>();
            services.AddScoped<IItemImageService, ItemImageService>();
            services.AddScoped<IImgBBService, ImgBBService>();
            services.AddScoped<IReturnPolicyService, ReturnPolicyService>();

            services.AddHttpClient();
            services.AddHttpClient<IImgBBService, ImgBBService>();
            return services;
        }
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme (\"{token}\")",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    });
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Jewellery API", Version = "v1" });
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                }
            );

            services.AddHttpContextAccessor();
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddScopedService();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();

            return services;
        }

        public static WebApplication AddWebApplicationMiddleware(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<GlobalExceptionMiddleware>();

            return webApplication;
        }
    }
}
