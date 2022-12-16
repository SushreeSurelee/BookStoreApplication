using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel AddOrder(OrderModel order, int userId);
        public List<GetOrderModel> GetAllOrders(int userId);
        public bool DeleteOrder(int orderId);
    }
}
