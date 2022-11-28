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
    }
}
