using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConfig.Services;

namespace TestConfig.Controllers
{
    public class DashBoardController : Controller
    {
        private IDatabaseService _databaseService;
        public DashBoardController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            var name = "a";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
