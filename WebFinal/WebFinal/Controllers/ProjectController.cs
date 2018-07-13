using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFinal.Controllers.Api;
using WebFinal.Models;
using WebFinal.ViewModels;

namespace WebFinal.Controllers
{
    public class ProjectController : Controller
    {
        public List<City> dataCity = new List<City>();
        private DataContext context;

        public ProjectController()
        {
            context = new DataContext();
            dataCity = new List<City>();
        }

        // GET: Project
        public ActionResult Index()
        {
            FormsViewModel forms = new FormsViewModel();
            return View(forms);
        }

        [HttpPost]
        public ActionResult Save(FormsViewModel viewModel)
        {
            context.DForm.Add(viewModel.DataForm);
            var dataCity = viewModel.ListofCity.Find(x => x.Id == viewModel.DataForm.City);

            context.SaveChanges();

            return RedirectToAction("SecondView", new { bookingId = viewModel.DataForm.Id,cityName=dataCity.Name});
        }

        public ActionResult SecondView(int bookingId,string cityName)
        {
            var result = context.DForm.Find(bookingId);
            result.NameC = cityName;
            GoToData(result.City);
           
            return View(result);
        }

        private void GoToData(int city)
        {
          
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}