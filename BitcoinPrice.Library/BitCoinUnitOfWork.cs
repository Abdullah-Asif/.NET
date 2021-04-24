using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class BitCoinUnitOfWork : UnitOfWork, IBitCoinUnitOfWork
    {
      public IBitCoinPriceRepository BitCoinPriceRepository { get; set; }


        public BitCoinUnitOfWork( BitCoinContext bitCoinContext , IBitCoinPriceRepository bitCoinPriceRepository
                                                                 )
            :base(bitCoinContext)
        {
            BitCoinPriceRepository = bitCoinPriceRepository;
          
        }
    }
}
