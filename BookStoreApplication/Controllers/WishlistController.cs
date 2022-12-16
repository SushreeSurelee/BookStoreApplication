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
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistBL wishlistBL;
        public WishlistController(IWishlistBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }
        [HttpPost("AddToWishlist")]
        public IActionResult AddToWishList(int bookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = wishlistBL.AddToWishList(bookId,userId);

                if (result)
                {
                    return this.Ok(new { success = true, message = "Item added to the wishlist", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "unable to add item to wishlist" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetAllWishlist")]
        public IActionResult GetAllWishlist()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = wishlistBL.GetAllWishlist(userId);
                if (result != null)
                {
                    return this.Ok(new { data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to get wishlist" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteWishlist(int wishlistId)
        {
            try
            {
                var result = wishlistBL.DeleteWishlist(wishlistId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Item deleted from Wishlist Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "unable to delete Item from wishlist" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
