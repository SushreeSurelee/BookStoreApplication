using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public CartModel AddToCart(CartModel cart, int userId)
        {
            try
            {
                return this.cartRL.AddToCart(cart, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CartModel UpdateCart(int cartId, CartModel cart, int userId)
        {
            try
            {
                return this.cartRL.UpdateCart(cartId, cart, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteCart(int cartId)
        {
            try
            {
                return cartRL.DeleteCart(cartId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetCartModel> GetCart(int userId)
        {
            try
            {
                return this.cartRL.GetCart(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
