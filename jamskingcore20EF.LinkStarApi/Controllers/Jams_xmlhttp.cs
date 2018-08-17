using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Collections;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    public class Jams_xmlhttp
    {
        BaseApiClass bac = new BaseApiClass();
        public Jams_xmlhttp()
        {
        }
        public string Postst(string request, string url, int timeout, string reqType, string resType)
        {
            string responseString = string.Empty;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = reqType;// + ";charset=\"utf-8\""
            webRequest.Accept = resType;// resType;
            webRequest.Method = "POST";
            webRequest.Timeout = timeout * 1000;
            try
            {
                byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(request);
                webRequest.ContentLength = bytes.Length;
                webRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
                HttpWebResponse response;//= (HttpWebResponse)webRequest.GetResponse();
                try
                {
                    response = (HttpWebResponse)webRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        responseString = reader.ReadToEnd();
                    }
                    throw new Exception(responseString);
                }
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
                {
                    responseString = reader.ReadToEnd();
                }
                return responseString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
   
