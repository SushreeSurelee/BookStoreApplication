using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public OrderModel AddOrder(OrderModel order, int userId)
        {
            try
            {
                return this.orderRL.AddOrder(order, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetOrderModel> GetAllOrders(int userId)
        {
            try
            {
                return this.orderRL.GetAllOrders(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            try
            {
                return this.orderRL.DeleteOrder(orderId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
