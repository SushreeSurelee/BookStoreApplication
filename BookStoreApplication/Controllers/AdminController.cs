using BussinesLayer.Interface;
using BussinesLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(LoginModel login)
        {
            try
            {
                var result = adminBL.AdminLogin(login);
                if (result != null)
                {
                    return this.Ok(new { sucess = true, message = "Admin Login Sucessfull.", data = result });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Admin Login Unsucessfull. Email or password is Invalid." });
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
                var result = adminBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { sucess = true, message = "Password reset mail has sent sucessfully." });
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
        [Authorize(Roles = Role.Admin)]
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = adminBL.ResetPassword(email, password, confirmPassword);
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
