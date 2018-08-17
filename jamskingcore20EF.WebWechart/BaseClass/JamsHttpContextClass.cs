using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace jamskingcore20EF.WebWechart.BaseClass
{
    public class JamsHttpContextClass
    {
        public static IServiceProvider ServiceProvider;

        public JamsHttpContextClass()
        { }


        public static HttpContext Current
        {
            get
            {
                object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));

                HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
                return context;
            }
        }
    }
}

