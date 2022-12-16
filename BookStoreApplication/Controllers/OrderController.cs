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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(OrderModel order)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = orderBL.AddOrder(order, userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Order Placed Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Order Place failed" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("Getorders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = orderBL.GetAllOrders(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = " Orders Fetched Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to Fetch Orders" });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var result = orderBL.DeleteOrder(orderId);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Order Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Order deletion failed" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
