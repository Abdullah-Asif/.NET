using BitcoinPrice.Library;
using BitcoinPrice.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.Web.Controllers
{
    public class ChartController : Controller
    {
        private IBitCoinUnitOfWork _bitCoinUnitOfWork;
        private BitCoinContext _dbContext;
        public ChartController( IBitCoinUnitOfWork bitCoinUnitOfWork, BitCoinContext bitCoinContext)
        {
            _bitCoinUnitOfWork = bitCoinUnitOfWork;
            _dbContext = bitCoinContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.BitCoinPrice
                .Include(x => x.bpi.USD)
                .Include( be => be.bpi.EUR)
                .Include( be => be.bpi.GBP)
                .Include(y => y.time).OrderByDescending( t => t.time.updatedISO).ToList();

            var avgUsd = _dbContext.BitCoinPrice.Include(a => a.bpi.USD).Average(x => x.bpi.USD.rate_float);
            var avgEur = _dbContext.BitCoinPrice.Include(a => a.bpi.EUR).Average(x => x.bpi.EUR.rate_float);
            var avgPound = _dbContext.BitCoinPrice.Include(a => a.bpi.GBP).Average(x => x.bpi.GBP.rate_float);

            var minUsd = _dbContext.BitCoinPrice.Include(a => a.bpi.USD).Min(x => x.bpi.USD.rate_float);
            var minEur = _dbContext.BitCoinPrice.Include(a => a.bpi.EUR).Min(x => x.bpi.EUR.rate_float);
            var minPound = _dbContext.BitCoinPrice.Include(a => a.bpi.GBP).Min(x => x.bpi.GBP.rate_float);

            var maxUsd = _dbContext.BitCoinPrice.Include(a => a.bpi.USD).Max(x => x.bpi.USD.rate_float);
            var maxEur = _dbContext.BitCoinPrice.Include(a => a.bpi.EUR).Max(x => x.bpi.EUR.rate_float);
            var maxPound = _dbContext.BitCoinPrice.Include(a => a.bpi.GBP).Max(x => x.bpi.GBP.rate_float);

            ViewBag.avgEur = avgEur;
            ViewBag.avgUsd = avgUsd;
            ViewBag.avgGbp = avgPound;

            ViewBag.maxUsd = maxUsd;
            ViewBag.maxEur = maxEur;
            ViewBag.maxGbp = maxPound;

            ViewBag.minUsd = minUsd;
            ViewBag.minEur = minEur;
            ViewBag.minGbp = minPound;


            return View(model);
        }
    }
}
