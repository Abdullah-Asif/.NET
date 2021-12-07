using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Entities
{
    public class BookPublisher
    {
        public int BookId { get; set; }
        public Book book { get; set; }
        public int PublisherId { get; set; }
        public Publisher publisher { get; set; }
    }
}
