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
    public class AddressController : Controller
    {
        private readonly IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost("Add")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var address = this.addressBL.AddAddress(addressModel, userId);
                if (address.Equals("Address Added Successfully"))
                {
                    return this.Ok(new { Status = true, Response = address });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Response = address });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateAddress(AddressModel addressModel, int addressId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var address = this.addressBL.UpdateAddress(addressModel, addressId, userId);
                if (address != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully Address Updated", Response = address });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "unsuucessfull Updation Enter Correct AddressId or TypeId" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("{UserId}/Get")]
        public IActionResult GetAllAddresses()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var addresses = this.addressBL.GetAllAddresses(userId);
                if (addresses != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully All Address Fetched NAnd Displayed", Response = addresses });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error! Please Enter Correct User Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
      
        [HttpDelete("Delete")]
        public IActionResult DeleteAddress(int addressId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.addressBL.DeleteAddress(addressId, userId))
                {
                    return this.Ok(new { Status = true, Message = " Successfully Address Deleted" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = " UnSuccessfull Deletion Please Enter Correct Address Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

    }
}
