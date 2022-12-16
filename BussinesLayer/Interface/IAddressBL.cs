using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface IAddressBL
    {
        public AddressModel AddAddress(AddressModel address, int userId);
        public AddressModel UpdateAddress(AddressModel address, int userId);
        public List<AddressModel> GetAddress(int userId);

    }
}
