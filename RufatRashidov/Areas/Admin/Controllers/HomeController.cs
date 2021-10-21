using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RufatRashidov.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area(nameof(Admin))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
