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
using RastreadorDeProblemasAPI.Models.dbModels;
using RastreadorDeProblemasAPI.Models.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RastreadorDeProblemasAPI", Version = "v1", Description = "Un simple API construido en ASP.Net Core para utilizar peticiones CRUD que controlan los problemas de una empresa ficticia." });

                c.ExampleFilters();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<ProblemaRequestExample>();

            // Ejecutareste comando en la terminal para actualizar los modelos, no olvidar borrar la clave que se genera en Context en OnConfiguring()
            // Scaffold-DbContext "Server=.\SQLEXPRESS;Database=IssueTracker;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/dbModels -DataAnnotations -Context RastreadorProblemasContext -Force
            services.AddDbContext<RastreadorProblemasContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RastreadorProblemasContext appdbcontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RastreadorDeProblemasAPI v1"));
            }

            InitDB.UpdateDB(appdbcontext);
            InitDB.SeedDefaultData(appdbcontext);

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
