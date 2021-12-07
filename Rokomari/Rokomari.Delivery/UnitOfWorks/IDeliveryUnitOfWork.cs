using Rokomari.Data;
using Rokomari.Delivery.Repositories.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.UnitOfWorks
{
    public interface IDeliveryUnitOfWork : IUnitOfWork
    {
        IBookRepository BookRepository { get; set; }
    }
}
