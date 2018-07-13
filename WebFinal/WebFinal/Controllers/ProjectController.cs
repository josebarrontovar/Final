using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.ViewModels;

namespace WebFinal.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            FormsViewModel forms = new FormsViewModel();
            return View(forms);
        }
    }
}