using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PSoft.Libraryd.AcessData;
using PSoft.Libraryd.AcessData.Commands;
using PSoft.Libraryd.AcessData.Queries;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.Queries;
using SqlKata.Compilers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace PSoft.Libraryd.API
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
            // dbContext
            var connectionString = Configuration.GetSection("ConnectionString").Value; //avoid
            services.AddDbContext<LibrarydDbContext>(options => options.UseSqlServer(connectionString));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2.0",
                    Title = "Libraryd API",
                    Description = "A simple Web API for booking and renting books from a library. Built in ASP.NET Core.",
                    Contact = new OpenApiContact
                    {
                        Name = "Nicolas Caro",
                        Email = "n-caro@outlook.com",
                        Url = new Uri("https://github.com/n-caro"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // SqlKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            // Dependency Inyections
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            // ClienteService
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteQuery, ClienteQuery>();
            // libros
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            services.AddTransient<ILibroQuery, LibroQuery>();
            // Alquiler
            services.AddTransient<IAlquilerServices, AlquilerServices>();
            services.AddTransient<IAlquilerQuery, AlquilerQuery>();
            services.AddTransient<IAlquilerRepository, AlquilerRepository>();
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
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Libraryd API v2");
            });
        }
    }
}
