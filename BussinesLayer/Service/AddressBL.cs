using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public AddressModel AddAddress(AddressModel address, int userId)
        {
            try
            {
                return this.addressRL.AddAddress(address, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public AddressModel UpdateAddress(AddressModel address, int userId)
        {
            try
            {
                return this.addressRL.UpdateAddress(address, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<AddressModel> GetAddress(int userId)
        {
            try
            {
                return this.addressRL.GetAddress(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
