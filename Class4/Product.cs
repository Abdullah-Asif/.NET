using System;
namespace Class4
 {
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public bool isAvailable()
        {
            return true;
        }
    }
}