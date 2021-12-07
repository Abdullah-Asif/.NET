using Rokomari.Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Threading.Tasks;
using Rokomari.Delivery.BusinessObjects;
using AutoMapper;

namespace Rokomari.Web.Areas.Admin.Models
{
    public class CreateBookModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public CreateBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }
        public CreateBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void AddBook()
        {
            var book = _mapper.Map<Book>(this);
            _bookService.AddBook(book);
        }

    }
}
