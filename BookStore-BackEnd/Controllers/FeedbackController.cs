﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackBL feedbackBL;

        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }
        [HttpPost("Add")]
        public IActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var feedback = this.feedbackBL.AddFeedback(feedbackModel, userId);
                if (feedback != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully Feedback For This Book Added ", Response = feedback });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "  Enter Correct BookId!!!!" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get")]
        public IActionResult GetFeedback(int bookId)
        {
            try
            {
                var result = this.feedbackBL.GetAllFeedback(bookId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Successfully Feedback For Given Book Id Fetched ANd Displayed ", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = " Enter Correct BookId" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateFeedback(FeedbackModel feedbackModel, int feedbackId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.feedbackBL.UpdateFeedback(feedbackModel, userId, feedbackId);
                if (result.Equals("Feedback For this Book is Updated Successfully"))
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
        [HttpPut("Delete")]
        public IActionResult DeleteFeedback(int feedbackId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.feedbackBL.DeleteFeedback(feedbackId, userId))
                {
                    return this.Ok(new { Status = true, Message = "Feedback Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "UnSuccessfull Deleting Feedback" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
