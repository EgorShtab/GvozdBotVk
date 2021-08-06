using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace GvozdBotVk
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
            var assembly = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assembly);
            services.Configure<ConfigureSettings>(Configuration.GetSection("VkSettings"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GvozdBotVk", Version = "v1" });
            });
            services.AddOptions();
            services.AddSingleton(sp =>
            {
                var vkApi = new VkApi();
                vkApi.Authorize(new ApiAuthParams
                {
                    AccessToken = Configuration["VkSettings:ApiKey"],
                    Settings = Settings.Messages
                });
                return vkApi;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GvozdBotVk v1"));
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
