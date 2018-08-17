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
using Microsoft.AspNetCore.Http;

namespace jamskingcore20EF.LinkStarApi
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
            services.AddDbContext<LinkStarApiDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("LSConnection")));
            services.AddDbContext<BaseApiDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("BAConnection")));
            
            services.AddMvc(options => 
            {
                options.ReturnHttpNotAcceptable = true;
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                //options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                //options.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
                //options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                // Input formatters
                var xmlInputFormatting = new XmlDataContractSerializerInputFormatter();
                var xmlOutputFormatting = new XmlDataContractSerializerOutputFormatter();
                //var jsonInputFormatting = new JsonInputFormatter();
                //jsonInputFormatting.SerializerSettings.Converters.Add(new BatchContentConverter());

                options.InputFormatters.Clear();
                //options.InputFormatters.Add(jsonInputFormatting);
                options.InputFormatters.Add(xmlInputFormatting);
                options.OutputFormatters.Add(xmlOutputFormatting);
                //options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
            });
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
