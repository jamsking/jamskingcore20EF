using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using jamskingcore20EF.Service;
using jamskingcore20EF.Service.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace jamskingcore20EF.WebApi
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
            services.AddMvc().AddMvcOptions(options => { options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
