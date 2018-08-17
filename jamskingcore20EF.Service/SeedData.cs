using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jamskingcore20EF.Service
{
    public static class SeedData

    {

        /// <summary>

        /// 

        /// 配置测试数据

        /// 

        /// </summary>

        public static void Initialize(IServiceProvider app)

        {

            var _dbContext = app.GetRequiredService<JDbContext>();



            //如果已经有数据就直接返回

            if (_dbContext.UserExtend.Any())

            {

                return;

            }

            //添加User测试数据

            _dbContext.UserExtend.Add(new Model.Model.tb_User { UserName = "Niko" });



            _dbContext.SaveChanges();



        }
    }
}
