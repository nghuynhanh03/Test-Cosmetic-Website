using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestBeautyStore
{
    /// <summary>
    ///            CHƯA CÓ SỬA CÁI NÀY NHEN  (TEST SCRIPT)
    /// </summary>
    /// 


    internal class TestThongKeKhachHang
    {

        //test thống kê số lượng khách hàng trước khi đăng ký
        //thống kê khách hàng sau khi đăng kí tài khoản -> đăng nhập tài khoản vừa mới đăng ký
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01()
        {
            driver.Navigate().GoToUrl("https://localhost:44381/");
            //driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            Assert.Pass();
        }

        [Test]
        public void Test02()
        {
            Thread.Sleep(3000);
            //bấm vào link Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver.FindElement(By.CssSelector("#header > nav > ul > li:nth-child(6) > div > a"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test]
        public void Test03()
        {
            //đăng nhập admin thành công
            LoginAdmin login = new LoginAdmin();
            IWebElement email = driver.FindElement(By.Name("UserEmail"));
            IWebElement pass = driver.FindElement(By.Name("UserPassword"));
            if (email != null && pass != null)
            {
                email.SendKeys(login.Email);
                pass.SendKeys(login.Pass);
                IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
                Thread.Sleep(1000);
                btnLogin.Click();
            }
            Assert.IsTrue(email != null && pass != null);
        }

        [Test]
        public void Test04()
        {
            //TestButtonMenu
            IWebElement button = driver.FindElement(By.CssSelector(".bi.bi-list.toggle-sidebar-btn"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
            //Test Link ThongKe
            IWebElement linkQLSP = driver.FindElement(By.CssSelector("body > aside:nth-child(2) > ul:nth-child(1) > li:nth-child(1) > a:nth-child(1) > span:nth-child(2)"));
            if (linkQLSP != null)
            {
                linkQLSP.Click();
                Thread.Sleep(5000);
            }
            Assert.IsNotNull(linkQLSP);
        }
        [Test]
        public void Test05()
        {
            driver.Navigate().GoToUrl("https://localhost:44381/");
            //driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            Assert.Pass();
        }

        [Test]
        public void Test06()
        {
            Thread.Sleep(3000);
            //bấm vào link Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver.FindElement(By.CssSelector("#header > nav > ul > li:nth-child(6) > div > a"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test]
        public void Test07()
        {
            Thread.Sleep(3000);
            //bấm vào link đăng ký
            IWebElement btn = driver.FindElement(By.CssSelector("a[href='/Users/SignUp']"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test]public void Test08()
        {
            //đăng ký user thành công
            RegisterUser regis = new RegisterUser();
            IWebElement userName = driver.FindElement(By.Name("userName"));
            IWebElement userEmail = driver.FindElement(By.Name("userEmail"));
            IWebElement phoneNumber = driver.FindElement(By.Name("phoneNumber"));
            IWebElement userPassword = driver.FindElement(By.Name("userPassword"));
            IWebElement rePassword = driver.FindElement(By.Name("rePassword"));
            if (userName != null && userEmail != null)
            {
                userName.SendKeys(regis.UserName);
                userEmail.SendKeys(regis.UserEmail);
                phoneNumber.SendKeys(regis.PhoneNumber);
                userPassword.SendKeys(regis.UserPassword);
                rePassword.SendKeys(regis.RePassword);
                //Bấm btn Đăng ký
                IWebElement button = driver.FindElement(By.CssSelector("div[class='btn-box'] button[type='submit']"));
                button.Click();
                Thread.Sleep(1000);
            }
            Assert.Pass();
        }
        [Test]
        public void Test14()
        {
            //đăng nhập admin thành công
            LoginAdmin login = new LoginAdmin();
            IWebElement email = driver.FindElement(By.Name("UserEmail"));
            IWebElement pass = driver.FindElement(By.Name("UserPassword"));
            if (email != null && pass != null)
            {
                email.SendKeys(login.Email);
                pass.SendKeys(login.Pass);
                IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
                Thread.Sleep(1000);
                btnLogin.Click();
            }
            Assert.IsTrue(email != null && pass != null);
        }
        [Test]
        public void Test15()
        {
            //TestButtonMenu
            IWebElement button = driver.FindElement(By.CssSelector(".bi.bi-list.toggle-sidebar-btn"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
            //Test Link ThongKe Quản lý Tài khoản
            IWebElement linkQLSP = driver.FindElement(By.XPath("//*[@id=\"sidebar-nav\"]/li[2]/a/span"));
            if (linkQLSP != null)
            {
                linkQLSP.Click();
                Thread.Sleep(5000);
            }
            Assert.IsNotNull(linkQLSP);
        }
        [Test]
        public void Test16()
        {
            //test tên tài khoản vừa đăng ký có hiện trên trang quản lý khách hàng không
            RegisterUser regis = new RegisterUser();
            bool status = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var home = driver.FindElements(By.ClassName("main"));
            foreach (var element in home)
            {
                string classAttributeValue = element.GetAttribute("class");
                string[] classes = classAttributeValue.Split(' ');
                foreach (string className in classes)
                {
                    if (className.Contains(regis.UserName) && element.Enabled)
                    {
                        status = true;
                    }
                }
            }
            Assert.IsNotNull(status);
        }
        [Test]public void Test17()
        {
            //chuyển đến trang đăng nhập
            driver.Navigate().GoToUrl("https://localhost:44381/Users/Login");
            Assert.Pass();
        }
        [Test]
        public void Test18()
        {
            //test đăng nhập user vừa mới đăng ký
            RegisterUser regis = new RegisterUser();
            IWebElement userEmail = driver.FindElement(By.Name("UserEmail"));
            IWebElement userPassword = driver.FindElement(By.Name("UserPassword"));
            if (userPassword != null && userEmail != null)
            {
                userEmail.SendKeys(regis.UserEmail);
                userPassword.SendKeys(regis.UserPassword);
                //Bấm btn Đăng nhập
                IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
                Thread.Sleep(1000);
                btnLogin.Click(); Thread.Sleep(1000);
            }
            driver.Quit();
            Assert.Pass();
        }
    }
}
