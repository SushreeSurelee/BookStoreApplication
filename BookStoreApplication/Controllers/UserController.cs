using BussinesLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult UserRegistration(Registration userRegistration)
        {
            try
            {
                Registration result = userBL.UserRegistration(userRegistration);
                if(result != null)
                {
                    return this.Ok(new { sucess = true, message = "User Registration Sucessfull.", data = result });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "User Registration Unsucessfull." });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(LoginModel login)
        {
            try
            {
                var result = userBL.UserLogin(login);
                if (result != null)
                {
                    return this.Ok(new { sucess = true, message = "User Login Sucessfull.", data = result });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Login Unsucessfull. Email or password is Invalid." });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("ForgotPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = userBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { sucess = true, message = "Password reset mail has sent sucessfully."});
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Failed to send the email. Please enter registred email ID." });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBL.ResetPassword(email, password, confirmPassword);
                if (result)
                {
                    return this.Ok(new { sucess = true, message = "Password reset is successfull" });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Password reset is failed. Please enter valid password" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
