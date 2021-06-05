using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Class6.Models;

namespace Class6.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Summary()
        {
            var model = new SummaryModel();
            return View(model);
        }
    }
}
