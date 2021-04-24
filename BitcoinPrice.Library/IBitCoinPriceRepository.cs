using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public interface IBitCoinPriceRepository : IGenericRepository<BitCoinPrice>
    {
        IEnumerable<BitCoinPrice> GetLastHourPrices();
    }
}
