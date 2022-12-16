using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }
        public FeedbackModel AddFeedback(FeedbackModel feedback, int userId)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedback, userId);
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
                return this.feedbackRL.GetAllFeedback(bookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
