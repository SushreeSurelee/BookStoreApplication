using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public Registration UserRegistration(Registration userRegistration)
        {
            try
            {
                return this.userRL.UserRegistration(userRegistration);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string UserLogin(LoginModel login)
        {
            try
            {
                return this.userRL.UserLogin(login);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                return this.userRL.ForgetPassword(email);
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
                return this.userRL.ResetPassword(email, password, confirmPassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
