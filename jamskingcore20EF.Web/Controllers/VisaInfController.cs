using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.Service.DBContexts;
using jamskingcore20EF.Service.PubJams;
using jamskingcore20EF.Model.VisaModels;
using jamskingcore20EF.Web.VisaViewModels;
using System.Collections.Generic;


namespace jamskingcore20EF.Web.Controllers
{
    public class VisaInfController : Controller
    {
        PubBaseClass pbc = new PubBaseClass();
        //展示
        static List<DbVisaapiVisaInf> DbVisaapiVisaInfList = new List<DbVisaapiVisaInf>();
        //数据库连接
        private VisaDbContext context;

        //控制器数据库定义
        public VisaInfController(VisaDbContext context)
        {
            this.context = context;
        }

        //需要加MODEL里面的东西，把例里的MODELS全部加到MODEL 里面，在共享文件夹里
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        #region 数据读取
        /// <summary>
        /// 显示页面
        /// </summary>
        /// <param name="name">查询字段</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetDSAll()
        {
            string VisaName = Request.Form["VisaName"];
            string VisaNat = Request.Form["VisaNat"];
            string VisaGol = Request.Form["VisaGol"];
            string sortOrder = Request.Form["sortOder"];

            string sortName = Request.Form["sortName"];
            int pageIndex = Convert.ToInt32(Request.Form["pageIndex"]);
            int pageSize = Convert.ToInt32(Request.Form["pageSize"]);
            var tempList = context.Set<DbVisaapiVisaInf>().ToList();
            if (!string.IsNullOrWhiteSpace(VisaName))
            {
                tempList = tempList.Where(p => p.VisaName.Contains(VisaName)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(VisaNat))
            {
                tempList = tempList.Where(p => p.VisaNat.Contains(VisaNat)).ToList();
            }
            if (sortOrder == "desc")
            {
                switch (sortName)
                {
                    case "visaInfId":
                        tempList = tempList.OrderByDescending(b => b.VisaInfId).ToList();
                        break;
                    case "visaName":
                        tempList = tempList.OrderByDescending(b => b.VisaName).ToList();
                        break;
                    case "visaNat":
                        tempList = tempList.OrderByDescending(b => b.VisaNat).ToList();
                        break;
                }
            }
            else
            {
                switch (sortName)
                {
                    case "visaInfId":
                        tempList = tempList.OrderBy(b => b.VisaInfId).ToList();
                        break;
                    case "visaName":
                        tempList = tempList.OrderBy(b => b.VisaName).ToList();
                        break;
                    case "visaNat":
                        tempList = tempList.OrderBy(b => b.VisaNat).ToList();
                        break;
                }

            }

            var currentPersonList = tempList
                                              .Skip((pageIndex - 1) * pageSize)
                                              .Take(pageSize);



            var result = new Dictionary<string, object>();
            //var limit = Convert.ToInt32(Request.Form["limit"]);//每页的个数
            //var offset = Convert.ToInt32(Request.Form["offset"]);//分页时数据的偏移量
            //var order = Request.QueryString["order"].ToString();//排序 asc desc

            var msg = "加载成功";
            try
            {
                var total = tempList.Count();
                var rows = currentPersonList.Select(b => new { VisaInfId = b.VisaInfId, VisaName = b.VisaName, VisaNat = b.VisaNat });

                result.Add("rows", rows);
                result.Add("total", total);
                result.Add("IsOk", true);
                result.Add("msg", msg);
            }
            catch (Exception ex)
            {
                msg = "加载失败";
                result.Add("IsOk", false);
                result.Add("msg", msg);
            }
            return Json(result);


        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var bVisaInf = context.Set<DbVisaapiVisaInf>().SingleOrDefault(b => b.VisaInfId == id);
            return View(bVisaInf);
        }
        /// <summary>
        /// 修改提交
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(DbVisaapiVisaInf_VMS VisaInfv, long? id)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    DbVisaapiVisaInf VisaInf = isNew ? new DbVisaapiVisaInf
                    {
                        CreatDate = DateTime.UtcNow,
                        CreatUser = VisaInfv.CreatUser
                    } : context.Set<DbVisaapiVisaInf>().SingleOrDefault(b => b.VisaInfId == id.Value);
                    VisaInf.VisaName = VisaInfv.VisaName;
                    VisaInf.VisaNat = VisaInfv.VisaNat;
                    VisaInf.VisaPrice = VisaInfv.VisaPrice;
                    VisaInf.VisaSettlement = VisaInfv.VisaSettlement;
                    VisaInf.VisaSOM = VisaInfv.VisaSOM;
                    VisaInf.VisaType = VisaInfv.VisaType;
                    VisaInf.VisaYear = VisaInfv.VisaYear;
                    VisaInf.IsDel = VisaInfv.IsDel;
                    VisaInf.ModifiedDate = DateTime.UtcNow;
                    VisaInf.ModifiedUser = VisaInfv.ModifiedUser;
                    VisaInf.VisaEXP = VisaInfv.VisaEXP;
                    VisaInf.VisaGOL = VisaInfv.VisaGOL;
                    if (isNew)
                    {
                        context.Add(VisaInf);
                    }
                    context.SaveChanges();
                    result["success"] = false;
                    result.Add("msg", "修改成功！");
                }
            }
            catch (Exception ex)
            {
                result["success"] = false;
                result.Add("msg", "修改失败！");
                throw ex;
            }


            return Json(result);
        }
        #endregion


        public ActionResult DeleteRow(int? id)
        {
            var result = new Dictionary<string, object>();
            var msg = "删除成功";
            var state = true;
            if (id == 0)
            {
                msg = "删除异常";
                state = false;
            }
            else
            {
                try
                {
                    DbVisaapiVisaInf VisaInf = context.Set<DbVisaapiVisaInf>().SingleOrDefault(c => c.VisaInfId == id);
                    context.Entry(VisaInf).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                    msg = "删除成功";
                    state = true;
                }
                catch (Exception ex)
                {
                    msg = "删除失败";
                    state = false;
                }
            }
            result.Add("state", state);
            result.Add("msg", msg);
            return Json(result);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            DbVisaapiVisaInf_VMS VisaInfv = new DbVisaapiVisaInf_VMS();
            if (id.HasValue)
            {
                DbVisaapiVisaInf VisaInf = context.Set<DbVisaapiVisaInf>().SingleOrDefault(c => c.VisaInfId == id.Value);
                if (VisaInf != null)
                {
                    VisaInfv.VisaInfId = VisaInf.VisaInfId;
                    VisaInfv.VisaName = VisaInf.VisaName;
                    VisaInfv.VisaNat = VisaInf.VisaNat;
                    VisaInfv.VisaPrice = VisaInf.VisaPrice;
                    VisaInfv.VisaSettlement = VisaInf.VisaSettlement;
                    VisaInfv.VisaSOM = VisaInf.VisaSOM;
                    VisaInfv.VisaType = VisaInf.VisaType;
                    VisaInfv.VisaYear = VisaInf.VisaYear;
                    VisaInfv.IsDel = VisaInf.IsDel;
                    VisaInfv.ModifiedDate = DateTime.UtcNow.ToString();
                    VisaInfv.ModifiedUser = VisaInf.ModifiedUser;
                    VisaInfv.VisaEXP = VisaInf.VisaEXP;
                    VisaInfv.VisaGOL = VisaInf.VisaGOL;
                }
            }
            return PartialView("~/Views/VisaInf/_AddEdit.cshtml", VisaInfv);
        }

        [HttpPost]
        public IActionResult AddEdit(int? id, DbVisaapiVisaInf_VMS VisaInfv)
        {
            var result = new Dictionary<string, object>();
            var msg = "出现异常";
            var state = false;
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (VisaInfv.VisaInfId == 0 || VisaInfv.VisaInfId == null)
                    {
                        isNew = true;
                    }
                    else
                    {
                        isNew = false;
                    }
                    DbVisaapiVisaInf VisaInf = isNew ? new DbVisaapiVisaInf
                    {
                        CreatDate = DateTime.UtcNow,
                        CreatUser = "暂时"
                    } : context.Set<DbVisaapiVisaInf>().SingleOrDefault(b => b.VisaInfId == VisaInfv.VisaInfId);
                    VisaInf.VisaName = VisaInfv.VisaName;
                    VisaInf.VisaNat = VisaInfv.VisaNat;
                    VisaInf.VisaPrice = VisaInfv.VisaPrice;
                    VisaInf.VisaSettlement = VisaInfv.VisaSettlement;
                    VisaInf.VisaSOM = VisaInfv.VisaSOM;
                    VisaInf.VisaType = VisaInfv.VisaType;
                    VisaInf.VisaYear = VisaInfv.VisaYear;
                    VisaInf.IsDel = VisaInfv.IsDel;
                    VisaInf.ModifiedDate = DateTime.UtcNow;
                    VisaInf.ModifiedUser = VisaInfv.ModifiedUser;
                    VisaInf.VisaEXP = VisaInfv.VisaEXP;
                    VisaInf.VisaGOL = VisaInfv.VisaGOL;
                    if (isNew)
                    {
                        context.Add(VisaInf);
                        msg = "添加成功";
                    }
                    else
                    {
                        msg = "修改成功";
                    }
                    context.SaveChanges();
                    state = true;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                state = false;
                msg = "修改失败" + ex;
            }
            result.Add("state", state);
            result.Add("msg", msg);
            return Json(result);
        }
        [HttpGet]
        public object contre(string con, string contype)
        {
            var stre = new object(); ;
            switch (con)
            {
                case "visaSOM":
                    stre = pbc.SOMdt();
                    break;
            }
            return stre;
        }
    }
}
