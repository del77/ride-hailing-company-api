using System.Reflection;
using AutoMapper;
using Core.Repositories;
using Core.Services;
using Infrastructure.DataAccess.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRidesService, RidesService>();
            
            services.AddScoped<ICustomersRepository, CustomersRepository>();
        }
        
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}