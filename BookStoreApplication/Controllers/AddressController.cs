using BussinesLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookStoreApplication.Controllers
{
    [Authorize(Roles = Role.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost("AddAddress")]
        public IActionResult AddAddress(AddressModel address)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = addressBL.AddAddress(address, userId);

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Address Addedd Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to add address" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel address)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = addressBL.UpdateAddress(address, userId);

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Address Updated Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to update address" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("Getalladdress")]
        public IActionResult GetAddress()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = addressBL.GetAddress(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Address Fetched Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to get addresses" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
