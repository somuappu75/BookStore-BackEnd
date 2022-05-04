using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface IOrderBL
    {
        public AddingOrderModel AddOrder(AddingOrderModel orderModel, int userId);
        public List<GetOrderModel> GetAllOrders(int userId);
    }
}
