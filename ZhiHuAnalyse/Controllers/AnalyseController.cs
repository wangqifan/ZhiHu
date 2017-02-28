using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace ZhiHuAnalyse.Controllers
{
    public class AnalyseController : Controller
    {
        //
        // GET: /Analyse/
        private ZhihuEntity Entity = new ZhihuEntity();
        //
        // GET: /Analyse/
        public ActionResult AnalyseForSex()
        {
            var users = Entity.user;
            int Mancount = users.Where(u => u.gender == 1).Count();
            int WomanCount = users.Where(u => u.gender == 0).Count();
            int UnKnow = users.Where(u => u.gender == -1).Count();
            ViewData["man"] = Mancount;
            ViewData["woman"] = WomanCount;
            ViewData["unknow"] = UnKnow;
            return View();
        }
        public ActionResult  AnalyseForSchool()
        {
            return View();
        }
	}
}