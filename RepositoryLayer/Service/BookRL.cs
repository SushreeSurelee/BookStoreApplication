using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public BookModel addBook(BookModel book)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddBookData", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);
                    cmd.Parameters.AddWithValue("@BookRating", book.BookRating);
                    cmd.Parameters.AddWithValue("@RatingCount", book.RatingCount);
                    cmd.Parameters.AddWithValue("@DiscountPrice", book.DiscountPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", book.ActualPrice);
                    cmd.Parameters.AddWithValue("@BookDetail", book.BookDetail);

                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }

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
                using (this.sqlConnection)
                {
                    List<BookModel> bookList = new List<BookModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllBooks", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    SqlDataReader result = cmd.ExecuteReader();
                    if(result.HasRows)
                    {
                        while(result.Read())
                        {
                            BookModel book = new BookModel
                            {
                                BookName = Convert.ToString(result["BookName"]),
                                Author = Convert.ToString(result["Author"]),
                                BookImage = Convert.ToString(result["BookImage"]),
                                BookRating = Convert.ToDouble(result["BookRating"]),
                                RatingCount = Convert.ToInt32(result["RatingCount"]),
                                DiscountPrice = Convert.ToDouble(result["DiscountPrice"]),
                                ActualPrice = Convert.ToDouble(result["ActualPrice"]),
                                BookDetail = Convert.ToString(result["BookDetail"]),
                            };
                            bookList.Add(book);
                        }
                        this.sqlConnection.Close();
                        return bookList;
                    }
                    else
                    {
                        return null;
                    }
                }
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
                using (this.sqlConnection)
                {
                    BookModel bookModel = new BookModel();
                    SqlCommand cmd = new SqlCommand("spGetBookById", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    SqlDataReader result = cmd.ExecuteReader();
                    if(result.HasRows)
                    {
                        while(result.Read())
                        {
                            bookModel.BookName = Convert.ToString(result["BookName"]);
                            bookModel.Author = Convert.ToString(result["Author"]);
                            bookModel.BookImage = Convert.ToString(result["BookImage"]);
                            bookModel.BookRating = Convert.ToDouble(result["BookRating"]);
                            bookModel.RatingCount = Convert.ToInt32(result["RatingCount"]);
                            bookModel.DiscountPrice = Convert.ToDouble(result["DiscountPrice"]);
                            bookModel.ActualPrice = Convert.ToDouble(result["ActualPrice"]);
                            bookModel.BookDetail = Convert.ToString(result["BookDetail"]);
                        }
                        this.sqlConnection.Close();
                        return bookModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
