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
    public class OrderController : Controller
    {
        private readonly IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [HttpPost("Add")]
        public IActionResult AddOrder(AddingOrderModel orderModel)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(u => u.Type == "Id").Value);
                var order = this.orderBL.AddOrder(orderModel, userId);
                if (order != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully Order Placed", Response = order });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = " UnsuccessFull Enter Correct BookId" });
                }
            }
            catch (Exception ex)
            {
              return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(u => u.Type == "Id").Value);
                var order = this.orderBL.GetAllOrders(userId);
                if (order != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully Order Details Displayed", Response = order });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Add Login Creditionals To Get Or View Orders" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

    }
}
