using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data.Repositories;
using PetShop.Infrastructure.EntityFramework;
using PetShop.Infrastructure.EntityFramework.Repositories;
using PetShop.Infrastructure.Security.Helpers;
using PetTypeRepository = PetShop.Infrastructure.EntityFramework.Repositories.PetTypeRepository;

namespace PetShop.WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PetShop.WebAPI", Version = "v1"});
            });
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            services.AddDbContext<PetShopDBContext>(
                options =>
                {
                    options
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=petshop.db");
                });
            services.AddDbContext<SecurityContext>(
                opt =>
                {
                    opt
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=users.db");
                });
            
            services.AddScoped<IPetRepositories, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeRepositories, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddSingleton<IAuthenticationHelper, AuthenticationHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop.WebAPI v1"));
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var petShopContext = scope.ServiceProvider.GetService<PetShopDBContext>();
                    var securityContext = scope.ServiceProvider.GetService<SecurityContext>();
                    petShopContext.Database.EnsureDeleted();
                    securityContext.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}