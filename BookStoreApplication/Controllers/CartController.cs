using BussinesLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace BookStoreApplication.Controllers
{
    [Authorize(Roles = Role.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        [HttpPost("Add")]
        public IActionResult AddToCart(CartModel cart)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = cartBL.AddToCart(cart, userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Added to cart", data = result });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart add failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateCart(int cartId, CartModel cart)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = cartBL.UpdateCart(cartId, cart, userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Update Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart Update failed" });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                var result = cartBL.DeleteCart(cartId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Cart Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to delete the cart" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetCart")]
        public IActionResult GetCart()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = cartBL.GetCart(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Fetched Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "unable to get cart" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
