using Microsoft.EntityFrameworkCore;
using Rokomari.Delivery.Entities;

namespace Rokomari.Delivery.Contexts
{
    public interface IDeliveryContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Electronics> Electronics { get; set; }
    }
}