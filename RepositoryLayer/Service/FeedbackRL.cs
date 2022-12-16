using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FeedbackRL : IFeedbackRL
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public FeedbackModel AddFeedback(FeedbackModel feedback, int userId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddFeedback", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@BookRating", feedback.BookRating);
                    cmd.Parameters.AddWithValue("@Comment", feedback.Comment);
                    cmd.Parameters.AddWithValue("@BookId", feedback.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return feedback;
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
        public List<GetFeedbackModel> GetAllFeedback(int bookId)
        {
            try
            {
                using (this.sqlConnection)
                {
                    List<GetFeedbackModel> feedbacklist = new List<GetFeedbackModel>();
                    SqlCommand cmd = new SqlCommand("spGetFeedback", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    SqlDataReader result = cmd.ExecuteReader();

                    if (result.HasRows)
                    {
                        while(result.Read())
                        {
                            GetFeedbackModel feedback = new GetFeedbackModel
                            {
                                BookId = Convert.ToInt32(result["BookId"]),
                                FeedbackId = Convert.ToInt32(result["FeedbackId"]),
                                UserId = Convert.ToInt32(result["UserId"]),
                                Comment = Convert.ToString(result["Comment"]),
                                BookRating = Convert.ToDouble(result["BookRating"]),
                                FullName = Convert.ToString(result["FullName"])
                            };
                            feedbacklist.Add(feedback);
                        }
                        this.sqlConnection.Close();
                        return feedbacklist;
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
