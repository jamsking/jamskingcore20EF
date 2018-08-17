using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using jamskingcore20EF.Service;
using jamskingcore20EF.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using jamskingcore20EF.WebWechart.BaseClass;

namespace jamskingcore20EF.WebWechart
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
            //20180808 SESSION使用

            services.AddDbContext<JDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("JConnection")));
            services.AddDbContext<JADbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("JConnection")));
            services.AddDbContext<VisaDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("VisaConnection")));
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var lscon = Configuration.GetConnectionString("LSConnection");
            var bacon = Configuration.GetConnectionString("BAConnection");
            //var devcon = Configuration["ConnectionStrings:DevConnection"];
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
        
    }
}
