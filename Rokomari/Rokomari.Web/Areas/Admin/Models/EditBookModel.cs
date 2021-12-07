using Rokomari.Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Rokomari.Delivery.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Rokomari.Web.Areas.Admin.Models
{
    public class EditBookModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(5, ErrorMessage ="Name should be less than 5 characters")]
        public string Name { get; set; }
        [Required, MaxLength(10, ErrorMessage = "Name should be less than 5 characters")]
        public string Author { get; set; }
        [Required, Range(100, 5000)]
        public double? Price { get; set; }


        private IBookService _bookService;
        private readonly IMapper _mapper;
      
        public EditBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void LoadBookData(int id)
        {
            var book = _bookService.GetBook(id);
            _mapper.Map(book, this);
        }

        internal void Update()
        {

            var book = _mapper.Map<Book>(this);
            _bookService.UpdateBook(book);
        }
    }
}
