using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace WebApiTesting
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
            //services.AddDbContext<ProductoContext>(opt => opt.UseInMemoryDatabase("ProductoList"));
            var conexion = Configuration.GetConnectionString("InventarioDatabase");
            services.AddDbContext<InventarioContext>(options => options.UseSqlServer(conexion));
            services.AddScoped<DbContext, InventarioContext>();
            //services.AddTransient<IGenericRepository<Productos>, ExampleRepository<Productos>>();
            services.AddTransient<IGenericRepository<Productos>, GenericRepository<Productos>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:1841",
                                    "https://localhost:1841").AllowAnyMethod().AllowAnyHeader();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
