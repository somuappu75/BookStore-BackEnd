using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
  public  class CartBL:ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        //Calling Add Cart APi Method
        public CartModel AddCart(CartModel cartModel, int userId)
        {
            try
            {
                return this.cartRL.AddCart(cartModel, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Display cart for the ALl User id 

        public List<DispalyCart> GetCartDetailsByUser(int userId)
        {
            try
            {
                return this.cartRL.GetCartDetailsByUserid(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Uopdate cart api method 
        public CartModel UpdateCart(CartModel cartModel, int userId)
        {
            try
            {
                return this.cartRL.UpdateCart(cartModel, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Delete cart 
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="userId"></param>
        /// <returns>delete method calling </returns>
        public bool DeleteCart(int cartId, int userId)
        {
            try
            {
                return this.cartRL.DeleteCart(cartId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
