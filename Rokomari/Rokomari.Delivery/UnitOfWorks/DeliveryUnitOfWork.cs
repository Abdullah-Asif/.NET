using Rokomari.Data;
using Rokomari.Delivery.Contexts;
using Rokomari.Delivery.Repositories.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.UnitOfWorks
{
    public class DeliveryUnitOfWork : UnitOfWork, IDeliveryUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public DeliveryUnitOfWork(IDeliveryContext dbContext, IBookRepository book)
            :base((DeliveryContext)(dbContext))
        {
            BookRepository = book;
        }

    }
}
