using System.Reflection;
using System.Text;
using Application.Services;
using AutoMapper;
using Core.Factories;
using Core.Repositories;
using Core.Services;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Identity;
using Infrastructure.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRidesService, RidesService>();

            services.AddScoped<IRidesFactory, RidesFactory>();

            services.AddScoped<IRidesRepository, RidesRepository>();
            services.AddScoped<ICouponsRepository, CouponsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
        }
        
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load(nameof(Application)));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSettings<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddAuthentication(config =>
                {
                    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<Infrastructure.Identity.IdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}