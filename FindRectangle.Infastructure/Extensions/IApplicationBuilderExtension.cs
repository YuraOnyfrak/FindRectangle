using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Infastructure.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder, IWebHostEnvironment env)
        {

            builder.UseSwagger(c => c.RouteTemplate =  "swagger/{documentName}/swagger.json");

            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Test task");
                c.RoutePrefix = "swagger";
            });


            if (env.IsDevelopment())
                builder.Use(async (context, next) =>
                {
                    if (context.Request.Path.Value == "/")
                        context.Response.Redirect("/swagger", true);
                    else
                        await next();
                });

            return builder;
        }

    }
}
