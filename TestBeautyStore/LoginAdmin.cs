using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBeautyStore
{
    public class LoginAdmin
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public LoginAdmin()
        {
            Email = "admin@gmail.com";
            Pass = "admin@123";
        }
    }
}
