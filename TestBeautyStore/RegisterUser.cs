using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBeautyStore
{
    internal class RegisterUser
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public string RePassword { get; set; }
        public RegisterUser()
        {
            UserName = "Kiểm định A06";
            UserEmail = "a06666@gmail.com";
            PhoneNumber = "0123459999";
            UserPassword= "kiemdinh@123";
            RePassword = "kiemdinh@123";
        }
    }
}
