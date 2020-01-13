using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelamentoJurosWebApi.Infraestrutura;
using ParcelamentoJurosWebApi.Repositories;
using ParcelamentoJurosWebApi.Repositories.Impl;
using ParcelamentoJurosWebApi.Services;
using ParcelamentoJurosWebApi.Services.Impl;

namespace ParcelamentoJurosWebApi {
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Cors
            services.AddCors(options =>
                options.AddPolicy(
                    "AllowAll", p => {
                        p.AllowAnyOrigin();
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                    }));

            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            var connectionString = Configuration["connectionStrings:parcelamentoJuros"];
            if (Environment.IsProduction())
                connectionString = Configuration["connectionStrings:parcelamentoJurosProd"];

            services.AddDbContext<ParcelamentoJurosContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<ISimulacaoService, SimulacaoService>();
            services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("AllowAll");
        }
    }
}