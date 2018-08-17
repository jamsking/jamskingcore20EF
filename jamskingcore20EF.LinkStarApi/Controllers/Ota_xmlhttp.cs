using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    public class Ota_xmlhttp
    {
        BaseApiClass bac = new BaseApiClass();
        LinkStarApiClass lsac = new LinkStarApiClass();
        string username;
        string pwd;
        string url;
        string rcode;
        public Ota_xmlhttp()
        {
        }
        public Ota_xmlhttp(string _user, string _pwd, string _url,string _rcode)
        {
            username = _user;
            pwd = _pwd;
            url = _url;
            rcode = _rcode;
        }
        public string GetResponse(string requestXml,out string o_correlationID,out string o_TimeStamp,out string o_echoToken)
        {
            var xmlString = "";
            requestXml = requestXml.Replace("<? xml version =\"1.0\" encoding=\"UTF-8\"?>\n", "");
            var correlationID = "";
            var timeStamp = "";
            var echoTokenResp = "";
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Post;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.ContentType = "application/xml";
                request.UserAgent = "Mozilla/5.0(compatible;MSIE9.0;WindowsNT6.1;Trident/5.0;";
                if (username != null && pwd != null)
                {
                    var user_pwd = username + ":" + pwd;
                    byte[] authBytes = Encoding.UTF8.GetBytes(user_pwd.ToCharArray());
                    //Basic后有空格
                    request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(authBytes));
                    request.Headers.Add("Content-Encoding", "gzip");
                    request.Headers.Add("Accept-Encoding", "gzip");
                    var echoToken = rcode;
                    Regex regex = new Regex("^[A-Za-z0-9]{0,128}$");
                    if (regex.IsMatch(echoToken))
                    {
                        request.Headers.Add("EchoToken", echoToken);
                    }
                }
                var data = Encoding.UTF8.GetBytes(requestXml);
                var stream = request.GetRequestStream();
                var gzipstream = new GZipStream(stream, CompressionMode.Compress);

                gzipstream.Write(data, 0, data.Length);
                gzipstream.Close();
                var response = (HttpWebResponse)request.GetResponse();
               
                foreach (var item in response.Headers.AllKeys)
                {
                    if (item.Equals("CorrelationID"))
                    {
                        correlationID = response.Headers[item];
                    }
                    else if (item.Equals("TimeStamp"))
                    {
                        timeStamp = response.Headers[item];
                    }
                    else if (item.Equals("EchoToken"))
                    {
                        echoTokenResp = response.Headers[item];
                    }
                }
                if (echoTokenResp == rcode)
                {
                   
                    Stream responseStream = response.GetResponseStream();
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                    xmlString = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                else
                {
                    xmlString = "<echoToken>" + rcode + "</echoToken><echoTokenResp>" + echoTokenResp + "</echoTokenResp><correlationID>"+correlationID+"</correlationID><TimeStamp>"+timeStamp+"</TimeStamp>";
                }

            }
            catch (WebException e)
            {
                xmlString = e.Message;
            }
            o_correlationID = correlationID;
            o_TimeStamp = timeStamp;
            o_echoToken = echoTokenResp;
            return xmlString;
        }
    }
}
   
