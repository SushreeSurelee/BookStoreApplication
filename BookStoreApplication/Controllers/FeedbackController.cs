using BussinesLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL feedbackBL;

        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost("Addfeedback")]

        public IActionResult AddFeedback(FeedbackModel feedback)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = feedbackBL.AddFeedback(feedback, userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "FeedBack added Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to add feedback" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize(Roles = Role.User)]
        [HttpGet("GetAllFeedBack")]
        public IActionResult GetAllFeedback(int bookId)
        {
            try
            {
                var result = feedbackBL.GetAllFeedback(bookId);
                if (result != null)
                {
                    return (this.Ok(new { success = true, message = "Feedback fetched Successfully", data = result }));
                }
                else
                {
                    return (this.BadRequest(new { success = false, message = "unable to fetch feedback" }));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
