using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface IFeedbackBL
    {
        public FeedbackModel AddFeedback(FeedbackModel feedback, int userId);
        public List<GetFeedbackModel> GetAllFeedback(int bookId);
    }
}
