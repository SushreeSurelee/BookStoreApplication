using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddToCart(CartModel cart, int userId);
        public CartModel UpdateCart(int cartId, CartModel cart, int userId);
        public bool DeleteCart(int cartId);
        public List<CartModel> GetCart(int userId);
    }
}
