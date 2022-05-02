using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
  public   class Login
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
    }
}
