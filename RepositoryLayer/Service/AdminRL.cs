using CommonLayer.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        public IConfiguration Configuration { get; }

        public AdminRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
        public string AdminLogin(LoginModel login)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAdminLogin", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@EmailId", login.EmailId);
                    cmd.Parameters.AddWithValue("@Password", login.Password);

                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        int UserId = 0;

                        while (result.Read())
                        {
                            login.EmailId = Convert.ToString(result["EmailId"]);
                            login.Password = Convert.ToString(result["Password"]);
                            UserId = Convert.ToInt32(result[UserId]);
                        }
                        return GenerateSecurityToken(login.EmailId, UserId);
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
            { sqlConnection.Close(); }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spforgetPW", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@EmailId", email);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.RecordsAffected != 0)
                    {
                        int userId = 0;
                        while (reader.Read())
                        {
                            email = Convert.ToString(reader["EmailId"]);
                            userId = Convert.ToInt32(reader["UserId"]);

                        }
                        sqlConnection.Close();
                        var token = GenerateSecurityToken(email, userId);
                        MSMQModel mSMQModel = new MSMQModel();
                        mSMQModel.sendData2Queue(token);
                        return token.ToString();
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
        public bool ResetPassword(string email, string password, string confirmPassword)
        {
            try
            {
                using (this.sqlConnection)
                {
                    if (password.Equals(confirmPassword))
                    {
                        SqlCommand cmd = new SqlCommand("spResetPW", this.sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();

                        cmd.Parameters.AddWithValue("@EmailId", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
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
        public string GenerateSecurityToken(string email, long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(80),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
