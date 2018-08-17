using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.WebWechart.BaseClass;

namespace jamskingcore20EF.WebWechart.Controllers
{
    public class SubscriptController : Controller
    {
        //WeCharBaseClass wcbc = new WeCharBaseClass();
        [HttpGet]
        // GET: Subscript/ViewAccessToken
        /// <summary>获取AccessToken</summary>
        /// <returns></returns>
        public ActionResult ViewAccessToken()
        {
            return View();
        }
        [HttpGet]
        // GET: Subscript/GetAccessToken
        /// <summary>获取AccessToken</summary>
        /// <returns></returns>
        public ActionResult GetAccessToken()
        {
            string weaccesstoken = HttpContext.Session.GetString("access_Token");
            WeCharBaseClass wcbc = new WeCharBaseClass("wx3b34761bc34215f9", "c875356cc71378545ba61db4a0b30fdf", weaccesstoken,"7200");
            var rest = wcbc.GetToken();
            return Content(rest);
        }
        // GET: Subscript
        public ActionResult Index()
        {
            return View();
        }

        // GET: Subscript/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subscript/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscript/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscript/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subscript/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscript/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subscript/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}