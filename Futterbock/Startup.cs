using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Futterbock.Service.Service;
using Futterbock.Context;
using Microsoft.AspNetCore.Routing;
using Futterbock.Repository;

namespace Futterbock
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
            services.AddDbContext<FutterbockContext>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IngredientsRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Futterbock", Version = "v1" });
            });
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    // Force HTTPs on non-localhost machines
                    options.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        var scheme = httpReq.Host.Host.StartsWith("localhost", StringComparison.OrdinalIgnoreCase) ? httpReq.Scheme : "https";
                        swagger.Servers = new List<OpenApiServer>() { new OpenApiServer() { Url = $"{scheme}://{httpReq.Host}" } };
                    });
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Futterbock v1"));
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
