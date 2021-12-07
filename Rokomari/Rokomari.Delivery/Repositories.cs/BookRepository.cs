using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Rokomari.Delivery.Entities;
using Rokomari.Data;
using Rokomari.Delivery.Contexts;

namespace Rokomari.Delivery.Repositories.cs
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(IDeliveryContext dbContext) : base ((DeliveryContext)(dbContext))
        {
         
        }
      
    }
}
