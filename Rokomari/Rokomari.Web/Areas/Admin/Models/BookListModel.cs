using Rokomari.Delivery.Services;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rokomari.Delivery.BusinessObjects;
using Rokomari.Infrastructure;

namespace Rokomari.Web.Areas.Admin.Models
{
    public class BookListModel
    {
        private IBookService _bookService;
        public IList<Book> Books { get; set; }
        public BookListModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public BookListModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void GetBooksList()
        {
            Books = _bookService.GetAllBooks();
        }

        internal object GetBooks(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _bookService.GetBooks(
              dataTablesModel.PageIndex,
              dataTablesModel.PageSize,
              dataTablesModel.SearchText,
              dataTablesModel.GetSortText(new string[] { "Name", "Author", "Price"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name.ToString(),
                            record.Author.ToString(),
                            record.Price.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
