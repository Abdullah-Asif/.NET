using Rokomari.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Entities
{
    public class Publisher : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookPublisher> PublisherBooks { get; set; }
    }
}
