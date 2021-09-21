using EmployeeDetails.Interfaces.Repos;
using EmployeeDetails.Repos;
using EmployeeDetails.Repos.Interfaces;
using EmployeeDetails.Services;
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
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails
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
            services.AddCors();

            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<IEmployeeServices, EmployeeServices>();

            services.AddTransient<IDepartmentRepo,DepartmentRepo>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();

            services.AddDbContext<EmployeeContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmployeeConnection")));
            services.AddDbContext<DepartmentContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmployeeConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("version1", new OpenApiInfo { Title = "Employees API", Version = "version1" });
            });

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/version1/swagger.json", "Employee API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
