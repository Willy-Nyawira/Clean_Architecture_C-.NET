using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using CleanArchWithCQRSandMediator.Infra.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchWithCQRSandMediator.Domain.Repository;
using CleanArchWithCQRSandMediator.Infra.Repository;


namespace CleanArchWithCQRSandMediator.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<BlogDbContext> (options=>
                options.UseSqlServer(configuration.GetConnectionString("BlogdbContext") ??
                    throw new InvalidOperationException("connection string 'BlogdbContext not found"))
            );

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
