using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RufatRashidov.Models;
using RufatRashidov.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RufatRashidov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbPortfolio _context;

        public HomeController(ILogger<HomeController> logger, DbPortfolio context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVm vm = new()
            {
                Home = _context.IndexHome.FirstOrDefault(),
                About = _context.Abouts.FirstOrDefault(),
                Services = _context.Services.OrderByDescending(x => x.ModifiedOn).Take(4).ToList(),
                CodingSkill = _context.CodingSkill.OrderByDescending(x => x.ModifiedOn).Take(8).ToList(),
                ToolSkill = _context.Skills.OrderByDescending(x => x.ModifiedOn).Take(8).ToList(),
                Educations = _context.Educations.OrderByDescending(x => x.ModifiedOn).Take(8).ToList(),
                Experiences = _context.Experiences.OrderByDescending(x => x.ModifiedOn).Take(4).ToList(),
                Projects = _context.Projects.Include(x => x.Category).ToList(),
                Categories = _context.Categories.ToList(),
                Contact = _context.Contacts.FirstOrDefault()
            };
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
