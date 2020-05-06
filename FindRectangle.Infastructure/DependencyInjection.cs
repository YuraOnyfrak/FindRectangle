using FindRectangle.Application.Common.Interfaces;
using FindRectangle.Application.Queries.GetCountRectangleQuery;
using FindRectangle.Infastructure.Database;
using FindRectangle.Infastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using MediatR;

namespace FindRectangle.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFindRectangleService, FindRectangleService>();
            services.AddMediatR(typeof(GetCountRectangleQuery).Assembly);

            return  services.AddDbContext<AppDbContext>(options =>
                      options.UseMySql(
                          configuration.GetConnectionString("DefaultConnection"),
                          b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            
        }
    }
}
