using BitcoinPrice.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.Web.Models
{
    public class ViewModel
    {
        private IBitCoinUnitOfWork _bitCoinUnitOfWork;
        public ViewModel(IBitCoinUnitOfWork bitCoinUnitOfWork )
        {
            _bitCoinUnitOfWork = bitCoinUnitOfWork;
        }
        public IEnumerable<BitCoinPrice> GetAllPrice()
        {
           return _bitCoinUnitOfWork.BitCoinPriceRepository.GetAll();

        }
    }
}
