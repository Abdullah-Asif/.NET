using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoinPrice.Library
{
    public class BitCoinPrice : Entity
    {
        public Guid TimeId { get; set; }
        [ForeignKey("TimeId")]
        public virtual Time time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public Guid BpiId { get; set; }
        [ForeignKey("BpiId")]
        public virtual Bpi bpi { get; set; }
    }
}
