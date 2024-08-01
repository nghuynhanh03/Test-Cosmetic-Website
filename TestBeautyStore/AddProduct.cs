using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBeautyStore
{
    public class AddProduct
    {
        public string Image1 {  get; set; }
        public string Image2 { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string IntialPrice { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public AddProduct() 
        {
            Image1 = @"D:\BDCLPM LT\WebMTK-main\BeautyStore\image\kcn_larocheposay1.png";
            Image2 = @"D:\BDCLPM LT\WebMTK-main\BeautyStore\image\kcn_larocheposay2.png";
            Name = "Kem chống nắng Larocheposay Test";
            Amount = "3";
            Price = "300000";
            IntialPrice = "400000";
            BrandID = 1;
            CategoryID = 2;
        }
    }
}
