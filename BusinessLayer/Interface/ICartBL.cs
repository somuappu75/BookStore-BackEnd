using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface ICartBL
    {
        public CartModel AddCart(CartModel cartModel, int userId);
        public List<DispalyCart> GetCartDetailsByUser(int userId);
        public CartModel UpdateCart(CartModel cartModel, int userId);
        public bool DeleteCart(int cartId, int userId);
    }
}
