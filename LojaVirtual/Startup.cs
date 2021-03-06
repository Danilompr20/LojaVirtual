using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual
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
            //fazendo a inje��o da classe HTTpContext
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            services.AddDbContext<LojaVirtualContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("Context")));
            services.AddScoped<ICLienteRepository, ClienteRepository>();
            services.AddScoped<INewslatterRepository, NewslatterRepository>();


            // configurar sess�o
            services.AddMemoryCache();//guardar os dados na mem�ria
            services.AddSession(options=> { 
            
            });
            // fazendo a inje��o da classe sess�o para ser usado por outras classes

            services.AddScoped<Sessao>();
            services.AddScoped<LoginCliente>();

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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
