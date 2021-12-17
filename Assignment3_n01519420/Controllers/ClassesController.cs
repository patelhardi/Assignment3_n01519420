using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_n01519420.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        //we can use classcontroller to add and remove teacher from the class
    }
}