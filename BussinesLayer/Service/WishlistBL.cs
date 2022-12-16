using BussinesLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Service
{
    public class WishlistBL : IWishlistBL
    {
        private readonly IWishlistRL wishlistRL;
        public WishlistBL(IWishlistRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }
        public bool AddToWishList(int bookId, int userId)
        {
            try
            {
                return this.wishlistRL.AddToWishList(bookId, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<WishlistModel> GetAllWishlist(int userId)
        {
            try
            {
                return this.wishlistRL.GetAllWishlist(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeleteWishlist(int wishlistId)
        {
            try
            {
                return this.wishlistRL.DeleteWishlist(wishlistId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
