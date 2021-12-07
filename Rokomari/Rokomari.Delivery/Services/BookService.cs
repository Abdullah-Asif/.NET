using AutoMapper;
using Rokomari.Delivery.BusinessObjects;
using Rokomari.Delivery.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery.Services
{
    public class BookService : IBookService
    {
        private readonly IDeliveryUnitOfWork _deliveryUnitOfWork;
        private readonly IMapper _mapper;
        public BookService(IDeliveryUnitOfWork deliveryUnitOfWork, IMapper mapper)
        {
            _deliveryUnitOfWork = deliveryUnitOfWork;
            _mapper = mapper;
        }
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new InvalidOperationException("Book name can not be null");
            }

            if (isBookNameAlreadyExist(book.Name, book.Author))
            {
                throw new DuplicateWaitObjectException("Same Book Name and Author Name already Exist");
            }
            _deliveryUnitOfWork.BookRepository.Add(
                _mapper.Map<Entities.Book>(book));
            _deliveryUnitOfWork.Save();
        }

        public void DeleteBook(int id)
        {
            _deliveryUnitOfWork.BookRepository.Remove(id);
            _deliveryUnitOfWork.Save(); 
        }

        public IList<Book> GetAllBooks()
        {
            var booksEntities = _deliveryUnitOfWork.BookRepository.GetAll();
            var books = new List<Book>();

            foreach (var bookEntity in booksEntities)
            {
                var book = _mapper.Map<Book>(bookEntity);
                books.Add(book);
            }
            return books;
        }

        public Book GetBook(int id)
        {
            var book = _deliveryUnitOfWork.BookRepository.GetById(id);
            if (book == null) return null;
            return _mapper.Map<Book>(book);
        }

        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var booksData = _deliveryUnitOfWork.BookRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText)
                || x.Author.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);
           
            var resultData = (from book in booksData.data
                              select _mapper.Map<Book>(book)).ToList();

            return (resultData, booksData.total, booksData.totalDisplay);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new InvalidOperationException("Book is Missing");

            if (isBookNameAlreadyExist(book.Name, book.Id))
                throw new DuplicateWaitObjectException("Same Book Name already exist");

            var bookEntity = _deliveryUnitOfWork.BookRepository.GetById(book.Id);
            if (bookEntity != null)
            {
                _mapper.Map(book, bookEntity);
                _deliveryUnitOfWork.Save();
            }    
            else
            {
                throw new InvalidOperationException("Couldn't Find this Book");
            }
        }

        private bool isBookNameAlreadyExist(string name, string author) =>
            _deliveryUnitOfWork.BookRepository.GetCount(x => x.Name == name && x.Author == author) > 0;
        private bool isBookNameAlreadyExist(string name, int id) =>
            _deliveryUnitOfWork.BookRepository.GetCount(x => x.Name == name && x.Id != id) > 0;
    }
}
