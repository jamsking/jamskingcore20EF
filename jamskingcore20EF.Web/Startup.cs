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

namespace jamskingcore20EF.Web
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
            services.AddDbContext<JDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("JConnection")));
            services.AddDbContext<JADbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("JConnection")));
            services.AddDbContext<VisaDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("VisaConnection")));
            services.AddMvc();
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
