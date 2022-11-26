using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        public string AdminLogin(LoginModel login)
        {
			try
			{
				return this.adminRL.AdminLogin(login);

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
                return this.adminRL.ForgetPassword(email);
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
                return this.adminRL.ResetPassword(email, password, confirmPassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
