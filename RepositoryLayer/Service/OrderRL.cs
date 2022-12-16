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
    public class OrderRL : IOrderRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public OrderModel AddOrder(OrderModel order,int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddOrder", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@AddressId", order.AddressId);
                    cmd.Parameters.AddWithValue("@BookId", order.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if (result == 3)
                    {
                        return order;
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
        public List<GetOrderModel> GetAllOrders(int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    List<GetOrderModel> orderList = new List<GetOrderModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllOrders", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            GetOrderModel order = new GetOrderModel
                            {
                                OrderId = Convert.ToInt32(result["OrderId"]),
                                BookId = Convert.ToInt32(result["BookId"]),
                                AddressId = Convert.ToInt32(result["AddressId"]),
                                UserId = Convert.ToInt32(result["UserId"]),
                                TotalPrice = Convert.ToDouble(result["TotalPrice"]),
                                OrderQty = Convert.ToInt32(result["OrderQty"]),
                                OrderDate = Convert.ToDateTime(result["OrderDate"]),
                                BookName = Convert.ToString(result["BookName"]),
                                Author = Convert.ToString(result["Author"]),
                                BookImage = Convert.ToString(result["BookImage"]),
                                DiscountPrice = Convert.ToDouble(result["DiscountPrice"]),
                                ActualPrice = Convert.ToDouble(result["ActualPrice"]),
                            };
                            orderList.Add(order);
                        }
                        this.sqlConnection.Close();
                        return orderList;
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
        public bool DeleteOrder(int orderId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spRemoveOrder", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
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
