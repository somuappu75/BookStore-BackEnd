using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IOrderRL
    {
        public AddingOrderModel AddOrder(AddingOrderModel orderModel, int userId);
        public List<GetOrderModel> GetAllOrders(int userId);
    }
}
