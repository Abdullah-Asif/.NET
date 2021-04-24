using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public interface IBitCoinUnitOfWork:IUnitOfWork
    {
        IBitCoinPriceRepository BitCoinPriceRepository { get; set; }
    }
}
