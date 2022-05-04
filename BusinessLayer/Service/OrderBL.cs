﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public class OrderBL:IOrderBL
    {

        private readonly IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public AddingOrderModel AddOrder(AddingOrderModel orderModel, int userId)
        {
            try
            {
                return this.orderRL.AddOrder(orderModel, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<GetOrderModel> GetAllOrders(int userId)
        {
            try
            {
                return this.orderRL.GetAllOrders(userId);        
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
