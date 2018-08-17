
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace jamskingcore20EF.WebWechart.BaseClass
{
    public class WeCharBaseClass
    {
        private string appId;
        private string appSecret;
        string weaccess_token;
        string weexpires_in;
        public WeCharBaseClass()
        {
            //appId = "wx3b34761bc34215f9";
            //appSecret = "c875356cc71378545ba61db4a0b30fdf";
        }
        public WeCharBaseClass(string _appId,string _appSecret,string _weaccess_token,string _weexpires_in)
        {
            appId = _appId;
            appSecret = _appSecret;
            weaccess_token = _weaccess_token;
            weexpires_in = _weexpires_in;
        }
        public string AccessToken
        {
            get { return GetAccessToken(); }
        }
        /// <summary>获取access_token</summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private string GetAccessToken()
        {
            //string seaccess_token = _session.GetString("access_token");
            if (weaccess_token == null)
            {
                return GetToken();
            }
            //20180807
            var accessTokenCache = weaccess_token;
            if (accessTokenCache != null)
            {
                return accessTokenCache;
            }
            else
            {
                return GetToken();
            }
        }

        /// <summary>获取ccess_token</summary>
        /// <returns></returns>
        public string GetToken()
        {
            try
            {
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var responseData = client.DownloadString(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret));

                JObject jsonObj = JObject.Parse(responseData);

                var accessToken = jsonObj["access_token"].ToString();
                var expiresin = jsonObj["expires_in"].ToString();
                if (accessToken == null)
                {
                    return string.Empty;
                }
                return accessToken.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
