using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface IUserBL
    {
        public Registration UserRegistration(Registration userRegistration);
        public string UserLogin(LoginModel login);
    }
}
