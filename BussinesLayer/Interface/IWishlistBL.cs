using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interface
{
    public interface IWishlistBL
    {
        public bool AddToWishList(int bookId, int userId);
        public List<WishlistModel> GetAllWishlist(int userId);

        public bool DeleteWishlist(int wishlistId);
    }
}
