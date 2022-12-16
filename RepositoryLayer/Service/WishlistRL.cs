using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class WishlistRL : IWishlistRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public bool AddToWishList(int bookId,int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddToWishList", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if(result!=0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<WishlistModel> GetAllWishlist(int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    List<WishlistModel> listOfWishlistItem = new List<WishlistModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllWishlist", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader result = cmd.ExecuteReader();
                    if(result.HasRows)
                    {
                        while(result.Read())
                        {
                            WishlistModel wishlist = new WishlistModel
                            {
                                BookId = Convert.ToInt32(result["BookId"]),
                                UserId = Convert.ToInt32(result["UserId"]),
                                WishListId= Convert.ToInt32(result["WishListId"]),
                                BookName = Convert.ToString(result["BookName"]),
                                Author = Convert.ToString(result["Author"]),
                                BookImage = Convert.ToString(result["BookImage"]),
                                DiscountPrice = Convert.ToDouble(result["DiscountPrice"]),
                                ActualPrice = Convert.ToDouble(result["ActualPrice"])
                            };
                            listOfWishlistItem.Add(wishlist);
                        }
                        this.sqlConnection.Close();
                        return listOfWishlistItem;
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
        public bool DeleteWishlist(int wishlistId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteWishListItem", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@WishListId", wishlistId);
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
