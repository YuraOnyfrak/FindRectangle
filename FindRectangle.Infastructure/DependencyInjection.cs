using FindRectangle.Application.Common.Interfaces;
using FindRectangle.Infastructure.Database;
using FindRectangle.Infastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using MediatR;
using FindRectangle.Application.Queries;

namespace FindRectangle.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFindRectangleService, FindRectangleService>();
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddMediatR(typeof(GetCountRectangleQuery).Assembly);

            return  services.AddDbContext<AppDbContext>(options =>
                      options.UseMySql(
                          configuration.GetConnectionString("DefaultConnection"),
                          b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            
        }
    }
}
