using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.Service.PubJams;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    //[Produces("application/json")]
    //[Produces("application/xml")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        BaseApiClass bac = new BaseApiClass();
        VJson vj = new VJson();
        PubBaseClass pbc = new PubBaseClass();
     
        // POST: api/Login
        [HttpPost]
        [Consumes("application/xml")]
        public IActionResult Postxml([FromBody]object value)
        {
            string postString = "";
            string postString1 = "";
            Request.Body.Position = 0;
            using (var ms = new MemoryStream())
            {
                Request.Body.CopyTo(ms);
                var myByteArry = ms.ToArray();
                postString = Encoding.UTF8.GetString(myByteArry);
            }
            postString1 = bac.xmltojson(postString, "root");
            string json = postString1;
            
            string jsonxml = "";
            byte[] bytes = Encoding.UTF8.GetBytes(jsonxml);
            var response = File(bytes, "text/xml");
            if (vj.IsJson(json) == false)
            {
                json = bac.ResponseStatusre("2", "Json格式错误", "20031", "", "login post", HttpContext.Connection.RemoteIpAddress.ToString(), "", "", "");
                jsonxml = bac.Jsontoxml(json, "root").OuterXml.ToString();
               
                bytes = Encoding.UTF8.GetBytes(jsonxml);
                response = File(bytes, "text/xml");
                return response;
            }
            
            JObject jsonObj = JObject.Parse(postString1);
            string Apiusername = jsonObj["Apiusername"].ToString();
            string Apiuserpass = jsonObj["Apiuserpass"].ToString();
           
           
            postString = postString.Replace("<? xml version = \"1.0\" encoding=\"UTF-8\"?>", "");
           
            postString = postString.Replace("<root>", "");
            postString = postString.Replace("</root>", "");
            string ticket = "";
            if (bac.userticketpasschk(Apiusername, Apiuserpass) == true)
            {
                ticket = DateTime.Now.ToString();
                if (bac.userticketchkex(Apiusername) == false)
                {
                    string eticket = pbc.EncryptPassWord(ticket);
                    json = bac.ResponseStatusre("1", "获取Ticket成功", "10001", "", "login post", Apiusername,eticket,"","");

                }
                else
                {
                    string eticket = bac.Apiuserni(Apiusername, "ApiAccountRealPassWord");
                    json = bac.ResponseStatusre("1", "Ticket有效", "10002", "", "login post", Apiusername, eticket,"","");
                }
                
                
            }
            else
            {
                json = bac.ResponseStatusre("2", "用户名或密码错误", "20011", "", "login post", HttpContext.Connection.RemoteIpAddress.ToString(), "","","");
               
            }
            jsonxml = bac.Jsontoxml(json,"root").OuterXml.ToString();
            bytes = Encoding.UTF8.GetBytes(jsonxml);
            response = File(bytes, "text/xml");
            return response;
        }
      
    }
}
