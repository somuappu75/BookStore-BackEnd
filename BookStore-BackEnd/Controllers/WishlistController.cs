using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : Controller
    {
        private readonly IWishlistBL wishlistBL;

        public WishlistController(IWishlistBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }
        [HttpPost("Add")]
        public IActionResult AddInWishlist(int bookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.wishlistBL.AddWishlist(bookId, userId);
                if (result.Equals("Book is Successfully Added in Wishlist"))
                {
                    return this.Ok(new { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("{UserId}/Get")]
        public IActionResult GetAllWishlist()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var wishlist = this.wishlistBL.GetAllWishlist(userId);
                if (wishlist != null)
                {
                    return this.Ok(new { success = true, message = "Successfully All Wishlist Are Displayed ANd Fetched", response = wishlist });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Enter Correct User Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteWishlist(int wishlistId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.wishlistBL.DeleteWishlist(wishlistId, userId))
                {
                    return this.Ok(new { Status = true, Message = "Successfully Deleted Book From Wishlist" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Unsuccessfull Deletion  Wishlist" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

    }
}
