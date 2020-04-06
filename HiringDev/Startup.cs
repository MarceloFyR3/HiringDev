using System;
using System.Globalization;
using AutoMapper;
using HiringDev.Dominio.AutoMapper;
using HiringDev.INegocio.Negocios;
using HiringDev.Infra.Contexto;
using HiringDev.Infra.Repositorio;
using HiringDev.IRepositorio.Repositorio;
using HiringDev.Negocio.Negocio;
using HiringDev.Util.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HiringDev.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// variavel global
        /// </summary>
        public bool IsDev { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();

            AutoMapperConfig.RegisterMappings();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectString);
            });

            //Auto Mapper Configurations
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            MappingInterfaces(services);

            AutoMapperConfig.RegisterMappings();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API YouTube Segfy",
                    Description = "Exemplo ASP.NET Core 3.1 Web API, conectando com o youtube!",
                    TermsOfService = new Uri("https://github.com/MarceloFyR3/HiringDev"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcelo Drumand",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/MarceloFyR3"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "FyR3 Desenvolvimento",
                        Url = new Uri("https://github.com/MarceloFyR3"),
                    }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API YouTube Segfy");
            });

            app.UseCors(
                options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            IsDev = env.IsDevelopment();

            if (IsDev)
                app.UseDeveloperExceptionPage();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MappingInterfaces(IServiceCollection services)
        {
            //Mapeamentos de negócios
            services.AddScoped<IBuscarVideosYouTubeNegocio, BuscarVideosYouTubeNegocio>();

            services.AddScoped<IBuscaVideosYoutubeRepositorio, BuscaVideosYoutubeInfra>();
        }
    }
}
