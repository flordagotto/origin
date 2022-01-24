using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Origin.DataContext;
using Origin.DataLayer;
using Origin.DataLayer.Repo;
using Origin.Helpers;
using Origin.Services;
using Origin.Services.Repo;

namespace Origin
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
            services.AddControllersWithViews();

            services.AddDbContext<OriginContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("Connection")));

            // Agregar servicios al Scope
            services.AddScoped<ITarjetaService, TarjetaService>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<IRetiroService, RetiroService>();

            services.AddScoped<ITarjetaDao, TarjetaDao>();
            services.AddScoped<IBalanceDao, BalanceDao>();
            services.AddScoped<IRetiroDao, RetiroDao>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDtoProfile());
                ;
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IPinIncorrectTries, PinIncorrectTries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
