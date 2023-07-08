using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TicTacToeOnline.Data;

namespace TicTacToeOnline
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tic Tac Toe Online", Version = "v1" });
            });

            services.AddDbContext<GameContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerEndpointUrl = "/swagger/v1/swagger.json";
                string swaggerEndpointName = "Tic Tac Toe Online v1";

                // Verifica o ambiente e ajusta a URL do Swagger
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint(swaggerEndpointUrl, swaggerEndpointName);
                    c.RoutePrefix = string.Empty;
                }
                else
                {
                    string basePath = "/api"; // Altere para o caminho base da sua API, se necessário
                    c.SwaggerEndpoint($"{basePath}{swaggerEndpointUrl}", swaggerEndpointName);
                    c.RoutePrefix = string.Empty;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
