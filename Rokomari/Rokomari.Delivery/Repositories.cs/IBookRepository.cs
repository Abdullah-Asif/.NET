using Rokomari.Data;
using Rokomari.Delivery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Repositories.cs
{
    public interface IBookRepository : IRepository<Book, int>
    {
    }
}
