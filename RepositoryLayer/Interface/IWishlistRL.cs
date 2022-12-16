using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishlistRL
    {
        public bool AddToWishList(int bookId, int userId);
        public List<WishlistModel> GetAllWishlist(int userId);

        public bool DeleteWishlist(int wishlistId);
    }
}
