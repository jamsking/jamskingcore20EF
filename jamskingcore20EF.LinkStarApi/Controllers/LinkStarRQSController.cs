using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.Service.PubJams;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    //[Produces("application/xml")]
    [Route("api/LinkStarRQS")]
    public class LinkStarRQSController : Controller
    {
        BaseApiClass bac = new BaseApiClass();
        VJson vj = new VJson();
        PubBaseClass pbc = new PubBaseClass();
        LinkStarApiClass lasc = new LinkStarApiClass();
        // POST: api/LinkStarRQS
        [HttpPost]
        public ActionResult LinkStarPostx([FromBody]object value)
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
                json = bac.ResponseStatusre("2", "Json格式错误", "20031", "", "login post", HttpContext.Connection.RemoteIpAddress.ToString(), "","","");
                jsonxml = bac.Jsontoxml(json,"root").OuterXml.ToString();
                bytes = Encoding.UTF8.GetBytes(jsonxml);
                response = File(bytes, "text/xml");
                return response;
            }
            JObject jsonObj = JObject.Parse(postString1);
            string Apiusername = jsonObj["Apiusername"].ToString();
            string Apiticket = jsonObj["Apiticket"].ToString();
            string RQurl = jsonObj["RQurl"].ToString();
            postString = postString.Replace("\t\n", "");
            postString = postString.Replace("<? xml version = \"1.0\" encoding=\"UTF-8\"?>", "");
            postString = postString.Replace("<Apiusername>"+Apiusername+"</Apiusername>", "");
            postString = postString.Replace("<Apiticket>"+ Apiticket+ "</Apiticket>", "");
            postString = postString.Replace("<root>", "");
            postString = postString.Replace("</root>", "");
            postString = postString.Replace("<RQurl>"+ RQurl+ "</RQurl>", "");
            if (bac.userticketchk(Apiusername, Apiticket) == false)
            {
                json = bac.ResponseStatusre("2", "用户名或秘钥错误", "20012", "", "LinkStarRQS postxml", HttpContext.Connection.RemoteIpAddress.ToString(), "", "", "");
                jsonxml = bac.Jsontoxml(json, "root").OuterXml.ToString();
                bytes = Encoding.UTF8.GetBytes(jsonxml);
                response = File(bytes, "text/xml");
                return response;
            }
            else
            {
                string username = "shyb";
                string pwd = "QWhv3AVS6r8a";
                string rcode = bac.rerandomcode();
                string o_correlationID ="";
                string o_TimeStamp = "";
                string o_echoToken = "";
                //RQurl = "http://agibe.travelsky.com/ota/xml/QMsg";
                try
                {
                    Ota_xmlhttp oxh = new Ota_xmlhttp(username, pwd, RQurl,rcode);
                    var responseXml = oxh.GetResponse(postString,out o_correlationID,out o_TimeStamp,out o_echoToken);
                    jsonxml = responseXml;
                    bool rerecoderbl = lasc.ReRecoderre(o_echoToken, o_correlationID, o_TimeStamp, jsonxml, "LinkStarRQS postxml", Apiusername, DateTime.Now.ToString());
                    bool uprecoderbl = lasc.UpRecoderre(o_echoToken, bac.Apiuserni(Apiusername, "ApiAccountId"), bac.Apiuserni(Apiusername, "ApiAccountCode"), Apiusername, username, pwd, "LinkStarRQS postxml", RQurl, postString, DateTime.Now.ToString());
                    string recoderblst = "";
                   
                    if (rerecoderbl==false)
                    {
                        recoderblst += "接收未记录.";
                    }
                    if (uprecoderbl == false)
                    {
                        recoderblst += "提交未记录.";
                    }
                    json = bac.ResponseStatusre("1", recoderblst+"获取IBE+接口成功.", "10051", "", "LinkStarRQS postxml", Apiusername, Apiticket, rcode, postString1 + jsonxml);
                }
                catch(Exception ex)
                {

                    json = bac.ResponseStatusre("2", ex.ToString(), "20099", "", "LinkStarRQS postxml", Apiusername, Apiticket, rcode, postString1+jsonxml);
                }
                finally
                {
                    
                }
            }
            bytes = Encoding.UTF8.GetBytes(jsonxml);
            response = File(bytes, "text/xml");
            return response;
        }
       
    }
}
