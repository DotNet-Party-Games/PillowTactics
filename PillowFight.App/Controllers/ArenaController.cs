using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.App.Controllers
{
    public class ArenaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
