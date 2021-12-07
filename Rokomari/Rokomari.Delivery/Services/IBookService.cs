using Rokomari.Delivery.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        IList<Book> GetAllBooks();
        (IList<Book>records, int total, int totalDisplay) GetBooks
            (int pageIndex, int pageSize, string searchText, string sortText);
        Book GetBook(int id);
        void UpdateBook(Book course);
        void DeleteBook(int id);
    }
}
