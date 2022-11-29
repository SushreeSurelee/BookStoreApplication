using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
        public CartModel AddToCart(CartModel cart,int userId)
        {
			try
			{
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddToCart", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@BookId", cart.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return cart;
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
        public CartModel UpdateCart(int cartId,CartModel cart, int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCart", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if (result != 0)
                    {
                        return cart;
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
        public bool DeleteCart(int cartId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteCart", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@CartId", cartId);
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
        public List<CartModel> GetCart(int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    List<CartModel> cartlist = new List<CartModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllCart", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            CartModel cart = new CartModel
                            {
                                Quantity = Convert.ToInt32(result["Quantity"]),
                                BookId = Convert.ToInt32(result["BookId"])
                            };
                            cartlist.Add(cart);
                        }
                        this.sqlConnection.Close();
                        return cartlist;
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
