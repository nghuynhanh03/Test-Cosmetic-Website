using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBeautyStore
{
    internal class LoginCustomer
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public LoginCustomer()
        {
            Email = "nhomA06@gmail.com";
            Pass = "nhomA06@123";
        }
    }
}
