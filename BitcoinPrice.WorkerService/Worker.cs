using BitcoinPrice.Library;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitcoinPrice.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private static IBitCoinUnitOfWork _unitOfWork;
        private static BitCoinServiceBroker _broker;
        private static BitCoinContext _dbcontext;

        public Worker(ILogger<Worker> logger , IBitCoinUnitOfWork bitCoinUnitOfWork , BitCoinContext bitCoinContext)
        {
            _logger = logger;
            _dbcontext = bitCoinContext;
            _unitOfWork = bitCoinUnitOfWork;
            
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _broker = new BitCoinServiceBroker();
                var price = _broker.GetBitCoinPrices(); 
                _unitOfWork.BitCoinPriceRepository.Add(price);
                _unitOfWork.Save();
                _logger.LogInformation(price.time.updated + " " + price.bpi.USD);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
