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
    }
}
