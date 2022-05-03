﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IFeedbackRL
    {
        public FeedbackModel AddFeedback(FeedbackModel feedbackModel, int userId);
        public List<DisplayFeedback> GetAllFeedback(int bookId);
        public string UpdateFeedback(FeedbackModel feedbackModel, int feedbackId, int userId);
        public bool DeleteFeedback(int feedbackId, int userId);

    }
}
