using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        public BookModel addBook(BookModel book);
        public List<BookModel> GetAllBooks();
    }
}
