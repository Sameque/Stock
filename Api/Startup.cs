using DTO.Interfaces.Products;
using DTO.Model.Products;
using GlobalServices.CommandHandle.Products.Handlers;
using GlobalServices.Facade;
using GlobalServices.GlobalServices;
using GlobalServices.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories.Stock.Interface;
using Repositories.Stock.Repository;
using Repositories.Stock.Service;
using Repositories.Stock.Validations;
using RepositoryEF.Data;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            services.AddDbContext<RepositoryEFContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("dbTest"));
            });

            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<IProductGlobalServices, ProductGlobalServices>();
            services.AddScoped<IProductRepositoryService, ProductRepositoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepositoryValidate, ProductRepositoryValidate>();
            services.AddScoped<IProductHandler, ProductHandler>();
            services.AddScoped<IProductGlobalValidation, ProductGlobalValidation>();
            services.AddScoped<IProductNotification, ProductNotification>();
            services.AddScoped<IProductNotificationList, ProductNotificationList>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStaticFiles();  //Added Code

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    //c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1")
                    c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrating Swagger");
                        //c.InjectStylesheet("/swagger-custom/swagger-custom-styles.css");  //Added Code
                        c.InjectStylesheet("/swagger-custom/themes/3.x/theme-monokai.css");  //Added Code
                        c.InjectJavascript("/swagger-custom/swagger-custom-script.js", "text/javascript");  //Added Code
                        //c.RoutePrefix = string.Empty;
                        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrating Swagger");
                        //c.InjectStylesheet("/swagger-custom/swagger-custom-styles.css");
                    });
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrating Swagger");
                //    c.InjectStylesheet("/swagger-custom/swagger-custom-styles.css");  //Added Code
                //    c.InjectJavascript("/swagger-custom/swagger-custom-script.js", "text/javascript");  //Added Code
                //    c.RoutePrefix = string.Empty;
                //});
                ////app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
