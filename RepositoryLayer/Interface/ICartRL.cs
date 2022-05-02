using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface ICartRL
    {
        public CartModel AddCart(CartModel cartModel, int userId);
        public List<DispalyCart> GetCartDetailsByUserid(int userId);
        public CartModel UpdateCart(CartModel cartModel, int userId);
        public bool DeleteCart(int cartId, int userId);
    }
}
