using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class Time : Entity
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
        public string updateduk { get; set; }
    }
}
