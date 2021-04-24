using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitcoinPrice.Library
{

    public class BitCoinPriceRepository : GenericRepository<BitCoinPrice>, IBitCoinPriceRepository
    {
        private BitCoinContext _context;

        public BitCoinPriceRepository(BitCoinContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<BitCoinPrice> GetLastHourPrices()
        {
            var expectedTime = DateTime.UtcNow.AddHours(-1);
            return _context.BitCoinPrice.Where(x => x.time.updatedISO >= expectedTime).OrderBy(y => y.time.updatedISO).ToList();
        }
    }

}
