using OpenQA.Selenium.Chrome;//admin
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;
using System;

namespace TestBeautyStore
{
    /// <summary>
    ///            CHƯA CÓ SỬA CÁI NÀY NHEN   (TEST SCRIPT)
    /// </summary>
    /// 






    public class TestUserCancelOrder
    {

        //TEST user đặt hàng -> hủy đơn hàng
        //IWebDriver driver1;//admin
        IWebDriver driver2 = new EdgeDriver();//user
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01()
        {
            //truy cập trang user
            driver2.Navigate().GoToUrl("https://localhost:44381/");
            Assert.IsNotNull(driver2);
        }
        [Test]
        public void Test02()
        {
            //bấm vào Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver2.FindElement(By.CssSelector("#header > nav > ul > li:nth-child(6) > div > a"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test]
        public void Test03()
        {
            //đăng nhập user thành công
            LoginCustomer login = new LoginCustomer();
            IWebElement email = driver2.FindElement(By.Name("UserEmail"));
            IWebElement pass = driver2.FindElement(By.Name("UserPassword"));
            if (email != null && pass != null)
            {
                email.SendKeys(login.Email);
                pass.SendKeys(login.Pass);
                IWebElement btnLogin = driver2.FindElement(By.ClassName("btn"));
                Thread.Sleep(1000);
                btnLogin.Click();
            }
            driver2.Manage().Window.Maximize();
            Assert.IsTrue(email != null && pass != null);
        }
        [Test] public void Test04() 
        {
            //tìm sp muốn mua
            IWebElement searchBox = driver2.FindElement(By.CssSelector("input[placeholder='Tìm kiếm']"));
            searchBox.SendKeys("Nước tẩy trang"); Thread.Sleep(2000); // tìm tên sản phẩm vừa với thêm
            searchBox.SendKeys(Keys.Enter); // Nhấn Enter hoặc nút tìm kiếm
            Thread.Sleep(3000);
            Assert.Pass();
        }
        [Test] public void Test05() 
        {
            //bấm vô sản phẩm muốn mua sau khi tìm kiếm
            Actions actions = new Actions(driver2);
            IWebElement ele = driver2.FindElement(By.XPath("/html/body/main/div/div/div[2]/div[2]/div[1]/a"));
            actions.MoveToElement(ele);
            actions.Click();
            actions.Perform();
            //tăng số lượng sản phẩm lên 1 cái
            driver2.FindElement(By.Id("counter-plus")).Click();
            Assert.Pass();
        }
        [Test] public void Test06() 
        {
            //bấm btn thêm vào giỏ hàng
            IWebElement button = driver2.FindElement(By.ClassName("add-to-cart-btn"));
            if(button != null)
            {
                button.Click();
            }
            Assert.IsNotNull(button);
        }
        [Test] public void Test07() 
        {
            //bấm btn đặt hàng
            driver2.FindElement(By.CssSelector("body > main > div > div > div > div.col-lg-4 > div > form > input.btn.btn-danger")).Click();
            //nhập địa chỉ
            driver2.FindElement(By.Name("addressOrder")).SendKeys("828 Sư Vạn Hạnh"); Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test] public void Test08() 
        {
            ////bấm btn thanh toán
            IWebElement bt = driver2.FindElement(By.CssSelector("button[class='btn btn-info']"));
            Actions actions = new Actions(driver2);
            actions.MoveToElement(bt);
            actions.Click();
            actions.Perform();
            //IWebElement a = driver2.FindElement(By.CssSelector("tbody tr:nth-child(2) td:nth-child(4)"));
            Assert.Pass();
        }
        [Test] public void Test09() 
        {
            // Đảm bảo rằng trang web đã được tải và bảng hiển thị dữ liệu
            var wait = new WebDriverWait(driver2, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("/html/body/main/div/div/div[2]/div/table")).Displayed);

            // Lấy ô cuối cùng của dòng đầu tiên
            var lastCell = driver2.FindElement(By.CssSelector("tbody tr:nth-child(2) td:nth-child(5)"));

            // Lấy giá trị từ ô cuối cùng của dòng đầu tiên
            var lastCellValue = lastCell.Text;
            if(lastCellValue == "Chi tiết")
            {
                IWebElement click = driver2.FindElement(By.LinkText(lastCellValue));
                Actions actions = new Actions(driver2);
                actions.MoveToElement(click);
                actions.Click();//bấm vô xem chi tiết của đơn hàng mới nhất
                actions.Perform();
            }
            Assert.Pass();
        }
        [Test] public void Test10() 
        {
            IWebElement btn = driver2.FindElement(By.XPath("/html/body/main/div/div/div[2]/form/div/div[2]/a"));
            if(btn != null)
            {
                Actions actions = new Actions(driver2);
                actions.MoveToElement(btn);
                actions.Click();//bấm vô xem chi tiết của đơn hàng mới nhất
                actions.Perform();
                Thread.Sleep(1000);
            }
            driver2.Quit();
            Assert.Pass();
        }

    }
}