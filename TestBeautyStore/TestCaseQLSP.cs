//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestBeautyStore
//{
//    public class TestCaseQLSP
//    {
//        IWebDriver driver;
//        Function function = new Function();
//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Navigate().GoToUrl("https://localhost:44381/");
//            Thread.Sleep(1000);
//        }

//        [Test]
//        public void Test1()
//        {
//            //Thêm sản phẩm đúng
//            function.BamLinkLogin(driver); 
//            function.LoginAdmin(driver);
//            function.BamBtnMenu(driver); 
//            function.BamQLSP(driver);
//            function.ThemSP(driver);
//            //////viết code thêm vô


//            Assert.Pass();
//        }

//        [TearDown]
//        public void CloseTest()
//        {
//            driver.Quit();
//        }
//    }
//}
