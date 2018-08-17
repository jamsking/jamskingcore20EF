using System;
using jamskingcore20EF.Service.DBContexts;
using jamskingcore20EF.Service.PubJams;
using jamskingcore20EF.Model.ApiModels;
using jamskingcore20EF.LinkStarApi.ApiViewModels;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Data;

namespace jamskingcore20EF.LinkStarApi.Controllers
{

    public class BaseApiClass
    {
        PubBaseClass pbc = new PubBaseClass();
        AppSettingClass asc = new AppSettingClass();
        VJson vj = new VJson();
        private BaseApiDbContext _context;
        static List<ResponseStatus> ResponseStatusList = new List<ResponseStatus>();

        public BaseApiClass()
        {
        }
        public BaseApiClass(BaseApiDbContext context)
        {
            this._context = context;
            
        }
        public BaseApiDbContext _1context()
        {
            string connection=asc.appsetting("BAConnection");
            
            DbContextOptions<BaseApiDbContext> dbContextOption = new DbContextOptions<BaseApiDbContext>();
            DbContextOptionsBuilder<BaseApiDbContext> dbContextOptionBuilder = new DbContextOptionsBuilder<BaseApiDbContext>(dbContextOption);
            _context = new BaseApiDbContext(dbContextOptionBuilder.UseSqlServer(connection).Options);
            return _context;
        }
        #region 用户核验
        /// <summary>
        /// 秘钥核验
        /// </summary>
        /// <param name="apiusername">用户名</param>
        /// <param name="apiticket">秘钥</param>
        /// <returns></returns>
        public Boolean userticketchk(string apiusername, string apiticket)
        {
            this._1context();
            bool rebool = false;
            var tempList = _context.Set<ApiAccount>().ToList();
            if (!string.IsNullOrWhiteSpace(apiusername))
            {
                ///return rebool;
            }
            if (!string.IsNullOrWhiteSpace(apiticket))
            {
                ////return rebool;
            }
            tempList = tempList.Where(p => p.ApiAccountUserName.Contains(apiusername)).ToList();
            tempList = tempList.Where(p => p.ApiAccountRealPassWord.Contains(apiticket)).ToList();
            int count = tempList.Count;
            if (tempList.Count> 0)
            {
                rebool = true;
            }
            return rebool;
        }
        #endregion
        #region 用户核验
        /// <summary>
        /// 密码用户检验
        /// </summary>
        /// <param name="apiusername">用户名</param>
        /// <param name="apiuserpass">密码</param>
        /// <returns></returns>
        public Boolean userticketpasschk(string apiusername, string apiuserpass)
        {
            this._1context();
            bool rebool = false;
            var tempList = _context.Set<ApiAccount>().ToList();
            if (!string.IsNullOrWhiteSpace(apiusername))
            {
                ///return rebool;
            }
            if (!string.IsNullOrWhiteSpace(apiuserpass))
            {
                ///return rebool;
            }
            tempList = tempList.Where(p => p.ApiAccountUserName.Contains(apiusername)).ToList();
            tempList = tempList.Where(p => p.ApiAccountPassWord.Contains(pbc.EncryptPassWord(apiuserpass))).ToList();
            string testps = pbc.EncryptPassWord(apiuserpass);
            int count = Convert.ToInt32(tempList.Count());
            if (count > 0)
            {
                rebool = true;
            }
            return rebool;
        }
        #endregion
        public Boolean userticketchkex(string apiusername)
        {
            this._1context();
            string tm2st = "";
            ApiAccount ApiAccountMS = _context.Set<ApiAccount>().SingleOrDefault(c => c.ApiAccountUserName.Contains(apiusername));
            if (ApiAccountMS != null)
            {
                tm2st = ApiAccountMS.ExpTime.ToString();
            }
            if (tm2st == null || tm2st == "")
            {
                tm2st = "1900-01-01 00:00:00";
            }
            DateTime tm1 = Convert.ToDateTime(DateTime.Now.ToString());
            DateTime tm2 = Convert.ToDateTime(tm2st);
            TimeSpan tm3 = tm1 - tm2;
            if (tm3.Days > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string ResponseStatusre(string Success, string Message, string ErrorCode, string Information, string Position, string Apiusername, string eticket, string Apicode, string Remark)
        {
            this._1context();
            try
            {
                bool isNew = true;
                ResponseStatus ResponseStatusMS = isNew ? new ResponseStatus()
                {

                } : _context.Set<ResponseStatus>().SingleOrDefault();
                ResponseStatusMS.ApiCode = Apicode;
                ResponseStatusMS.ApiFrom = "";
                ResponseStatusMS.Remark = Remark;
                ResponseStatusMS.Success = Convert.ToInt32(Success);
                ResponseStatusMS.CreatDate = DateTime.Now;
                ResponseStatusMS.CreatUser = Apiusername;
                ResponseStatusMS.ModifiedDate = ResponseStatusMS.CreatDate;
                ResponseStatusMS.ModifiedUser = Apiusername;
                ResponseStatusMS.IsDel = 0;
                ResponseStatusMS.IsLock = 0;
                ResponseStatusMS.Errorcode = Convert.ToInt32(ErrorCode);
                ResponseStatusMS.Infmation = "";
                ResponseStatusMS.Message = Message;
                ResponseStatusMS.Position = Position;
                ResponseStatusMS.RSId = 0;
                if (isNew)
                {
                    _context.Add(ResponseStatusMS);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //string exst = ex.ToString();
            }
            finally
            {

            }
            string str = "";
            if (Success == "1")
            {
                if (this.userticketchkex(Apiusername) == false)
                {
                    resetetcode(Apiusername, eticket);
                }
            }
            str = "{\"Succes\":\"" + Success + "\",\"Message\":\"" + Message + "\",\"ErrorCode\":\"" + ErrorCode + "\",\"Information\":\"" + Information + "\",\"Position\":\"" + Position + "\",\"Apiusername\":\"" + Apiusername + "\",\"Apiticket\":\"" + eticket + "\",\"Remark\":\"" + Remark + "\"}";
            return str;
        }
        //20180803更新超时秘钥
        public void resetetcode(string username,string eticket)
        {
            this._1context();
            DateTime dts = DateTime.UtcNow;
            try
            {
                bool isNew = false;
                ApiAccount ApiAccountMS = isNew ? new ApiAccount()
                {

                } : _context.Set<ApiAccount>().SingleOrDefault(b => b.ApiAccountUserName == username);
                ApiAccountMS.ApiAccountRealPassWord =eticket;
                ApiAccountMS.ExpTime = Convert.ToDateTime(pbc.DecryptPassWord(eticket));
                ApiAccountMS.LoginTime = Convert.ToDateTime(pbc.DecryptPassWord(eticket));
                isNew = false;
                
                if (isNew)
                {
                    _context.Add(ApiAccountMS);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //string exst = ex.ToString();
            }
            finally
            {
            }
        }
        public XmlDocument Jsontoxml(string njson,string root)
        {
            //string njson2 = @"{""?xml"": {""@version"": ""1.0"",""encoding"": ""UTF-8""},""root"":" + njson + "}";
            XmlDocument doc2 = (XmlDocument)JsonConvert.DeserializeXmlNode(njson,root); ;
            return doc2;
        }
        public string xmltojson(string nxml,string root)
        {
            nxml = nxml.Replace("<? xml version =\"1.0\" encoding=\"UTF-8\"?>", "");
            nxml = nxml.Replace("<? xml version = \"1.0\" encoding=\"UTF-8\"?>", "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(nxml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            if (root != null && root!="")
            {
                json = json.Replace("{\"root\":", "");
                json = json.Substring(0, json.Length - 1);
            }
            return json;
        }
        public string Apiuserni(string apiusername, string userredt)
        {
            this._1context();
            string rest = "";
            ApiAccount ApiAccountMS = _context.Set<ApiAccount>().SingleOrDefault(c => c.ApiAccountUserName.Contains(apiusername));
            switch(userredt)
            {
                case "LoginTime":
                    rest = ApiAccountMS.LoginTime.ToString();
                        break;
                case "ApiAccountRealPassWord":
                    rest = ApiAccountMS.ApiAccountRealPassWord;
                    break;
                case "ApiAccountId":
                    rest = ApiAccountMS.ApiAccountId.ToString();
                    break;
                case "ApiAccountCode":
                    rest = ApiAccountMS.ApiAccountCode;
                    break;
                
            }
            return rest;
        }
        public string rerandomcode()
        {
            string code1 = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Month.ToString();
            if (DateTime.Now.Day.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Day.ToString();
            if (DateTime.Now.Hour.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Minute.ToString();
            if (DateTime.Now.Second.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond.ToString().Length < 2)
            {
                code1 += "0";
            }
            code1 += DateTime.Now.Millisecond.ToString();
            code1 += RandomNum(3);
            return code1;
        }
        public string RandomNum(int n) //
        {
            string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] VcArray = strchar.Split(',');
            string VNum = "";                    //
            int temp = -1;                       //记录上次随机数值，尽量避免产生几个一样的随机数
                                                 //采用一个简单的算法以保证生成随机数的不同
            Random rand = new Random();
            for (int i = 1; i < n + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return RandomNum(n);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;//返回生成的随机数
        }
    }
}
