using Backend_Preguntas_Repuestas.Domain.IRepositories;
using Backend_Preguntas_Repuestas.Domain.IServices;
using Backend_Preguntas_Repuestas.Persistence.Context;
using Backend_Preguntas_Repuestas.Persistence.Repositories;
using Backend_Preguntas_Repuestas.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas
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
            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            // Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();

            // Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            //Cors
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowWebApp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
