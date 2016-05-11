using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaSample.Controllers
{
    public class TemplateController : Controller
    {
        public ActionResult EventList()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        public ActionResult EventDetail()
        {
            return View();
        }
    }
}