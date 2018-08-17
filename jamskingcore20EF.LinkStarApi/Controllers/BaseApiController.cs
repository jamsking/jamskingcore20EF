using System;
using jamskingcore20EF.Service.DBContexts;
using jamskingcore20EF.Service.PubJams;
using jamskingcore20EF.Model.ApiModels;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace jamskingcore20EF.LinkStarApi.Controllers
{
    [Produces("application/json")]
    [Route("api/BaseApi")]
    public class BaseApiController : Controller
    {
        PubBaseClass pbc = new PubBaseClass();
        private BaseApiDbContext context;

        public BaseApiController(BaseApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/BaseApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #region 用户核验
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="name">查询字段</param>
        /// <returns></returns>
        public Boolean userticketchk(string apiusername, string apiticket)
        {
            bool rebool = false;
            var tempList = context.Set<ApiAccount>().ToList();
            if (!string.IsNullOrWhiteSpace(apiusername))
            {
                return rebool;
            }
            if (!string.IsNullOrWhiteSpace(apiticket))
            {
                return rebool;
            }
            tempList = tempList.Where(p => p.ApiAccountUserName.Contains(apiusername)).ToList();
            tempList = tempList.Where(p => p.ApiAccountRealPassWord.Contains(apiticket)).ToList();
            var count = tempList.Count();
            if (count > 0)
            {
                rebool = true;
            }
            return rebool;
        }
        #endregion
        #region 用户核验
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="name">查询字段</param>
        /// <returns></returns>
        public Boolean userticketpasschk(string apiusername, string apiuserpass)
        {
            bool rebool = false;
            var tempList = context.Set<ApiAccount>().ToList();
            if (!string.IsNullOrWhiteSpace(apiusername))
            {
                return rebool;
            }
            if (!string.IsNullOrWhiteSpace(apiuserpass))
            {
                return rebool;
            }
            tempList = tempList.Where(p => p.ApiAccountUserName.Contains(apiusername)).ToList();
            tempList = tempList.Where(p => p.ApiAccountPassWord.Contains(apiuserpass)).ToList();
            var count = tempList.Count();
            if (count > 0)
            {
                rebool = true;
            }
            return rebool;
        }
        #endregion
        public Boolean userticketchkex(string apiusername)
        {
            string tm2st = "";
            ApiAccount ApiAccountMS = context.Set<ApiAccount>().SingleOrDefault(c => c.ApiAccountUserName.Contains(apiusername));
            if (ApiAccountMS != null)
            {
                tm2st = ApiAccountMS.LoginTime.ToString();
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
            try
            {
                
                ResponseStatus ResponseStatusMS = new ResponseStatus();
                ResponseStatusMS.ApiCode = Apicode;

                ResponseStatusMS.ApiFrom = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                context.Add(ResponseStatusMS);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //string exst = ex.ToString();
            }
            finally
            {

            }
            string str = "{\"Succes\":\"" + Success + "\",\"Message\":\"" + Message + "\",\"ErrorCode\":\"" + ErrorCode + "\",\"Information\":\"" + Information + "\",\"Position\":\"" + Position + "\",\"Apiusername\":\"" + Apiusername + "\"}";
            if (eticket != "")
            {
                str = "{\"Succes\":\"" + Success + "\",\"Message\":\"" + Message + "\",\"ErrorCode\":\"" + ErrorCode + "\",\"Information\":\"" + Information + "\",\"Position\":\"" + Position + "\",\"Apiusername\":\"" + Apiusername + "\",\"Ticket\":\"" + eticket + "\"}";
            }
            return str;
        }
        public XmlDocument Jsontoxml(string njson)
        {
            XmlDocument doc2 = (XmlDocument)JsonConvert.DeserializeXmlNode(njson, "root"); ;
            return doc2;
        }
        // GET: api/BaseApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/BaseApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/BaseApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
