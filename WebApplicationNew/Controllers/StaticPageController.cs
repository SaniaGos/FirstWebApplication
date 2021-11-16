using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNew.Controllers
{
    public class StaticPageController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
