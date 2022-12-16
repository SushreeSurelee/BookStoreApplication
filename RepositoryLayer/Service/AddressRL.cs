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
    public class AddressRL : IAddressRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public AddressModel AddAddress(AddressModel address, int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddAddress", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@TypeId", address.Type);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if (result != 0)
                    {
                        return address;
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
        public AddressModel UpdateAddress(AddressModel address,int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAddress", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@AddressId", address.AddressId);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@TypeId", address.Type);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return address;
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
        public List<AddressModel> GetAddress(int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    List<AddressModel> addresses = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllAddress", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            AddressModel address = new AddressModel
                            {
                                AddressId = Convert.ToInt32(result["AddressId"]),
                                Address = Convert.ToString(result["Address"]),
                                City = Convert.ToString(result["City"]),
                                State = Convert.ToString(result["State"]),
                                Type = Convert.ToInt32(result["TypeId"]),
                            };
                            addresses.Add(address);
                        }
                        this.sqlConnection.Close();
                        return addresses;
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
