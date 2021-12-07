using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Entities
{
    public class Book : Product
    {
        public string Author { get; set; }
        public IList<BookPublisher> BookPublishers { get; set; }
    }
}
