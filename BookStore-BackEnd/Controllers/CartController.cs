using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        //addcart api calling
        [HttpPost("Add")]
        public IActionResult AddCart(CartModel cart)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cartdetails = this.cartBL.AddCart(cart, userId);
                if (cartdetails != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfully  Book Added in Cart", Response = cartdetails });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccessfull Adding" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("{UserId}/ Get")]
        public IActionResult GetCartDetailsByUser()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cartdetails = this.cartBL.GetCartDetailsByUser(userId);
                if (cartdetails != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfully cart Details Fetched", Response = cartdetails });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Enter Correct User Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        //update
        [HttpPut("Update")]
        public IActionResult UpdateCart(CartModel cartModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                var cart = this.cartBL.UpdateCart(cartModel, userId);
                if (cart != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfully Cart Details Updated", Response = cart });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull Cart Updation!!!" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        //delete
        [HttpDelete("Delete")]
        public IActionResult DeletCart(int cartId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "Id").Value);
                if (this.cartBL.DeleteCart(cartId, userId))

                {
                    return this.Ok(new { Success = true, message = "Sucessfully Cart Deleted " });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull Cart Deletion" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
