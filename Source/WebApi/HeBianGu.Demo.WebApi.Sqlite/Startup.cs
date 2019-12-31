using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HeBianGu.Demo.WebApi.Sqlite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //  Do ：注入数据库上下文
            services.AddDbContext<SqliteDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Do:注册Swagger生成器并初始化一个或多个文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HeBianGu API Base Demo",
                    Version = "v1",
                    Description = "API Base Demo for Asp.net Core 3.0",
                    TermsOfService = new Uri("https://blog.csdn.net/u010975589"),
                    Contact = new OpenApiContact
                    {
                        Name = "HeBianGu",
                        Email = string.Empty,
                        Url = new Uri("https://blog.csdn.net/u010975589")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OpenApiLicense",
                        Url = new Uri("https://blog.csdn.net/u010975589")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Do:启用中间件服务Swagger
            app.UseSwagger();

            // Do:启用中间件服务swagger-ui
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
