using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public BookModel addBook(BookModel book)
        {
            try
            {
                return this.bookRL.addBook(book);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<BookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public BookModel GetBookByID(int bookId)
        {
            try
            {
                return this.bookRL.GetBookByID(bookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
