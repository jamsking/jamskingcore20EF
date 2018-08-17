using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/TestPost")]
    public class TestPostController : Controller
    {
        Jams_xmlhttp jst = new Jams_xmlhttp();

        [HttpPost]
        public ActionResult TestPost([FromBody]object value)
        {
            string postString1 = "<? xml version = \"1.0\" encoding=\"UTF-8\"?><root><Apiusername>jamsking</Apiusername><Apiticket>C8B0AD2BCFC7ECF507EA1AA1C9959D798C974420CB9965B5</Apiticket><RQurl>http://agibe.travelsky.com/ota/xml/QMsg</RQurl><OTA_QMsgRQ><ActionCode>OPQT</ActionCode><Queue Office=\"SHA752\"></Queue></OTA_QMsgRQ></root>";
            string jsonxml = "";
            string url = "http://localhost:6773/api/LinkStarRQS/";
            jsonxml = jst.Postst(postString1, url, 500, "application/xml", "application/xml");
            byte[] bytes = Encoding.UTF8.GetBytes(jsonxml);
            var response = File(bytes, "text/xml");
            return response;
        }
    }
}