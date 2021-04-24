using BitcoinPrice.Library;
using BitcoinPrice.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BitCoinContext _context;
        private IBitCoinUnitOfWork _bitCoinUnitOfWork;


        public HomeController(ILogger<HomeController> logger , BitCoinContext bitCoinContext, IBitCoinUnitOfWork bitCoinUnitOfWork)
        {
            _logger = logger;
            _context = bitCoinContext;
            _bitCoinUnitOfWork = bitCoinUnitOfWork;
        }

        public IActionResult Index()
        {
            var broker = new BitCoinServiceBroker();
           var price = broker.GetBitCoinPrices();
            _bitCoinUnitOfWork.BitCoinPriceRepository.Add(price);
            _bitCoinUnitOfWork.Save();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
