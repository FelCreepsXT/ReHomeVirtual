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
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.Membership.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Persistence.Repositories;
using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Membership.Services;

namespace ReHomeVirtualBackEnd
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("rehomevirtual-api-in-memory");
            });

            //Repositories
            services.AddScoped<IAllergyRepository, AllergyRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<IAllergyService, AllergyService>();


            services.AddAutoMapper(typeof(Startup));
            services.AddCustomSwagger();
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

            app.UserCustomSwagger();
        }
    }
}
