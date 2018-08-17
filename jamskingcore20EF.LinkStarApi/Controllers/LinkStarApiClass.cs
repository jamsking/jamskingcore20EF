using System;
using jamskingcore20EF.Service.DBContexts;
using jamskingcore20EF.Service.PubJams;
using jamskingcore20EF.Model.ApiModels;
using jamskingcore20EF.Model.LinkStarApiModels;
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
    public class LinkStarApiClass
    {
        PubBaseClass pbc = new PubBaseClass();
        AppSettingClass asc = new AppSettingClass();
        VJson vj = new VJson();
        private LinkStarApiDbContext _context;
        static List<ResponseStatus> ResponseStatusList = new List<ResponseStatus>();
        static List<ReRecoder> ReRecoderList = new List<ReRecoder>();
        static List<UpRecoder> UpRecoderList = new List<UpRecoder>();
        public LinkStarApiClass()
        {

        }
        public LinkStarApiClass(LinkStarApiDbContext context)
        {
            this._context = context;
        }
        public LinkStarApiDbContext _1context()
        {
            string connection = asc.appsetting("LSConnection");

            DbContextOptions<LinkStarApiDbContext> dbContextOption = new DbContextOptions<LinkStarApiDbContext>();
            DbContextOptionsBuilder<LinkStarApiDbContext> dbContextOptionBuilder = new DbContextOptionsBuilder<LinkStarApiDbContext>(dbContextOption);
            _context = new LinkStarApiDbContext(dbContextOptionBuilder.UseSqlServer(connection).Options);
            return _context;
        }
        public bool ReRecoderre(string ApiEchoToken, string ApiCorrelationID, string TimeSpamp, string ApiReCon, string ApiFrom, string Apiusername, string LoginTime)
        {
            bool rebl = false;
            this._1context();
            try
            {
                bool isNew = true;
                ReRecoder ReRecoderm= isNew ? new ReRecoder()
                {

                } : _context.Set<ReRecoder>().SingleOrDefault();
                ReRecoderm.ApiEchoToken = ApiEchoToken;
                ReRecoderm.ApiCorrelationID = ApiCorrelationID;
                ReRecoderm.ApiFrom = ApiFrom;
                ReRecoderm.ApiReCon = ApiReCon;
                ReRecoderm.TimeSpamp = TimeSpamp;
               
                ReRecoderm.CreatDate = DateTime.Now;
                ReRecoderm.CreatUser = Apiusername;
                ReRecoderm.ModifiedDate = ReRecoderm.CreatDate;
                ReRecoderm.ModifiedUser = Apiusername;
                ReRecoderm.IsDel = 0;
                ReRecoderm.IsLock = 0;
                
                if (isNew)
                {
                    _context.Add(ReRecoderm);
                }
                _context.SaveChanges();
                rebl = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //string exst = ex.ToString();
            }
            finally
            {
                
            }
            return rebl;
        }

        public bool UpRecoderre(string ApiEchoToken, string ApiAccountId, string ApiAccountCode, string ApiAccountUserName, string ApiUsername,string ApiPassWord,string ApiFrom, string ApiUrl,string ApiCon,string LoginTime)
        {
            bool rebl = false;
            this._1context();
            try
            {
                bool isNew = true;
                UpRecoder UpRecoderm = isNew ? new UpRecoder()
                {

                } : _context.Set<UpRecoder>().SingleOrDefault();
                UpRecoderm.ApiEchoToken = ApiEchoToken;
                UpRecoderm.ApiAccountId = Convert.ToInt32(ApiAccountId);
                UpRecoderm.ApiFrom = ApiFrom;
                UpRecoderm.ApiCon = ApiCon;
                UpRecoderm.ApiAccountCode = ApiAccountCode;
                UpRecoderm.ApiAccountUserName = ApiAccountUserName;
                UpRecoderm.ApiUrl = ApiUrl;
                UpRecoderm.ApiSysUserName = ApiUsername;
                UpRecoderm.ApiSysPassWord = ApiPassWord;
                UpRecoderm.CreatDate = DateTime.Now;
                UpRecoderm.CreatUser = ApiAccountUserName;
                UpRecoderm.ModifiedDate = UpRecoderm.CreatDate;
                UpRecoderm.ModifiedUser = ApiAccountUserName;
                UpRecoderm.IsDel = 0;
                UpRecoderm.IsLock = 0;

                if (isNew)
                {
                    _context.Add(UpRecoderm);
                }
                _context.SaveChanges();
                rebl = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //string exst = ex.ToString();
            }
            finally
            {

            }
            return rebl;
        }
    }
}
