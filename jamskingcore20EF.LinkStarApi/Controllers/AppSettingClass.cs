using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    public class AppSettingClass
    {
        public AppSettingClass()
        {

        }
        public string appsetting(string con)
        {
            string ConfigPath = Environment.CurrentDirectory + @"\appsettings.json";
            string json = System.IO.File.ReadAllText(ConfigPath, Encoding.Default);
            JObject jsonConfig = (JObject)JsonConvert.DeserializeObject(json);
            string value = jsonConfig["ConnectionStrings"][con].ToString();
            return value;
        }

    }
}
