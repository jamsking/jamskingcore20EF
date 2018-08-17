using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.Service.PubJams;

namespace jamskingcore20EF.Web.Controllers
{
    public class NONBaseController : Controller
    {
        PubBaseClass pbc = new PubBaseClass();
        public IActionResult Index()
        {
            return View();
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
                case "visaGOL":
                    stre = pbc.GOLdt();
                    break;
            }
            return stre;
        }
    }
}