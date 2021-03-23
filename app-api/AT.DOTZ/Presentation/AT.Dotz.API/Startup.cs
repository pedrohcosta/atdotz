using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using AT.Dotz.API.Configurations;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceAccount;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AT.Dotz.API
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
            services.AddDbContext<ContextBase>(options =>
            {
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();

            services.AddScoped<ContextBase>();
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddScoped<IAccount, RepositoryAccount>();
            services.AddScoped<IAccountCard, RepositoryAccountCard>();
            services.AddScoped<IAccountExtract, RepositoryAccountExtract>();
            services.AddScoped<InterfaceAccountApp, AppAccount>();
            services.AddScoped<IServiceAccount, ServiceAccount>();

      
            services.AddSwaggerConfig();

            services.AddAutoMapperConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerConfig();
        }
    }
}
