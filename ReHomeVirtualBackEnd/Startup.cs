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
using ReHomeVirtualBackEnd.Routines.Domain.Repositories;
using ReHomeVirtualBackEnd.Routines.Persistence.Repositories;
using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Routines.Domain.Services;
using ReHomeVirtualBackEnd.Routines.Services;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Persistence.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Services;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Membership.Persistence.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Services;
using ReHomeVirtualBackEnd.Membership.Domain.Services;
using ReHomeVirtualBackEnd.Initialization.Persistence.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Services;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications;

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
            services.AddMvc();
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("rehomevirtual-api-in-memory");
            });

            //Repositories
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IDietRepository, DietRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IUserService, UserService>();

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
