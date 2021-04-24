using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoinPrice.Library
{
    public class Bpi : Entity
    {
        public Guid USDId { get; set; }
        [ForeignKey("USDId")]
        public  USD USD { get; set; }
        
        public Guid GBPId { get; set; }
        [ForeignKey("GBPId")]
        public  GBP GBP { get; set; }
  
        public Guid EURId { get; set; }
        [ForeignKey("EURId")]
        public  EUR EUR { get; set; }
    }
}
