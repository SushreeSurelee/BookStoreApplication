using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {

        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public Registration UserRegistration(Registration userRegistration)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddUserData", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@FullName", userRegistration.FullName);
                    cmd.Parameters.AddWithValue("@EmailId", userRegistration.EmailId);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@MobileNumber", userRegistration.MobileNumber);

                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return userRegistration;
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
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
