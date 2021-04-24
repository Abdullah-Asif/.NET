using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class USD : Entity
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public double rate_float { get; set; }
    }
}
