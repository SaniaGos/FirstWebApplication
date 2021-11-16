using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNew.Models;

namespace WebApplicationNew.Controllers
{
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}

    public class HomeController : Controller
    {
        ILeadRepository repo;
        public HomeController(ILeadRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetLeads());
        }

        public ActionResult Details(int id)
        {
            Lead lead = repo.Get(id);
            if (lead != null)
                return View(lead);
            return Redirect("~/StaticPage/Error");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Lead lead)
        {
            try
            {
                repo.Create(lead);
            }
            catch (Exception ex)
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Lead lead = repo.Get(id);
            if (lead != null)
                return View(lead);
            return RedirectToAction("Error", "StaticPage");
        }

        [HttpPost]
        public ActionResult Edit(Lead lead)
        {
            repo.Update(lead);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Lead lead = repo.Get(id);
            if (lead != null)
                return View(lead);
            return Redirect("~/StaticPage/Error");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
