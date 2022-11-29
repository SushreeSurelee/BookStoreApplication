using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface IBookBL
    {
        public BookModel addBook(BookModel book);
        public List<BookModel> GetAllBooks();
        public BookModel GetBookByID(int bookId);
        public BookModel UpdateBook(int bookId, BookModel book);
        public bool DeleteBook(int bookId);
    }
}
