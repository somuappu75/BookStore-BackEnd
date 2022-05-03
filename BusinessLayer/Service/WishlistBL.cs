using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public class WishlistBL:IWishlistBL
    {
        private readonly IWishlistRL wishlistRL;
        public WishlistBL(IWishlistRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }
        public string AddWishlist(int bookId, int userId)
        {
            try
            {
                return this.wishlistRL.AddWishlist(bookId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<WishlistModel> GetAllWishlist(int userId)
        {
            try
            {
                return this.wishlistRL.GetAllWishlist(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteWishlist(int wishlistId, int userId)
        {
            try
            {
                return this.wishlistRL.DeleteWishlist(wishlistId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
