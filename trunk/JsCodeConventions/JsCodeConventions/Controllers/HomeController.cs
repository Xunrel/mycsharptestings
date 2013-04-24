using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsCodeConventions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "JavaScript Code Conventions";

            return View();
        }

        public ActionResult Conventions()
        {
            return View();
        }

        [ActionName("Conventions2")]
        public ActionResult MoreConventions()
        {
            return View();
        }

        public ActionResult Classes()
        {
            return View();
        }

        public ActionResult CoffeeScript()
        {
            return View();
        }

        public ActionResult Libraries()
        {
            return View();
        }
    }
}
