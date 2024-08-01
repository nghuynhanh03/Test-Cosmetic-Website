using OpenQA.Selenium.Chrome;//admin
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;

namespace TestBeautyStore
{
    /// <summary>
    ///            CHƯA CÓ SỬA CÁI NÀY NHEN (TEST SCRIPT)
    /// </summary>
    /// 








    public class TestBrand
    {
        //Test thêm thương hiệu, xóa thương hiệu đó
        IWebDriver driver1 = new ChromeDriver();//admin
        //IWebDriver driver2 = new EdgeDriver();//user
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01()
        {
            driver1.Navigate().GoToUrl("https://localhost:44381/");
            Assert.IsNotNull(driver1);
        }
        [Test]
        public void Test02()
        {
            //bấm vào Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver1.FindElement(By.CssSelector("#header > nav > ul > li:nth-child(6) > div > a"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test]
        public void Test03()
        {
            //đăng nhập admin thành công
            LoginAdmin login = new LoginAdmin();
            IWebElement email = driver1.FindElement(By.Name("UserEmail"));
            IWebElement pass = driver1.FindElement(By.Name("UserPassword"));
            if (email != null && pass != null)
            {
                email.SendKeys(login.Email);
                pass.SendKeys(login.Pass);
                IWebElement btnLogin = driver1.FindElement(By.ClassName("btn"));
                Thread.Sleep(1000);
                btnLogin.Click();
            }
            Assert.IsTrue(email != null && pass != null);
        }
        [Test]
        public void Test04()
        {
            //TestButtonMenu
            IWebElement button = driver1.FindElement(By.CssSelector(".bi.bi-list.toggle-sidebar-btn"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
            //Test Link QL Brand
            IWebElement linkQLSP = driver1.FindElement(By.CssSelector("#sidebar-nav > li:nth-child(6) > a"));
            if (linkQLSP != null)
            {
                linkQLSP.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(linkQLSP);
        }
        [Test]
        public void Test05()
        {
            //test Link Thêm brand
            IWebElement themSP = driver1.FindElement(By.PartialLinkText("Thêm thương hiệu mới"));
            if (themSP != null)
            {
                themSP.Click();
            }
            Assert.Pass();
        }
        [Test]
        [TestCase("Thương hiệu 1")]
        public void Test06(string txtBrand)
        {
            //test thêm tên thương hiệu
            IWebElement name = driver1.FindElement(By.Name("BrandName"));
            name.SendKeys(txtBrand);
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test]
        public void Test07()
        {
            //thêm hình ảnh
            IWebElement image1 = driver1.FindElement(By.Name("ImgBrand"));
            String filePath1 = @"D:\BDCLPM LT\WebMTK-main\BeautyStore\image\COCOON.png";
            image1.SendKeys(filePath1);
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test]public void Test08()
        {
            var wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(20));
            //bấm btn thêm mới
            IWebElement btn = driver1.FindElement(By.CssSelector("button[class='btn btn-success']"));
            if(btn != null)
                btn.Click();
            Assert.Pass();
        }
        [Test]
        [TestCase("Thương hiệu 1")]
        public void Test09(string txtBrand)
        {
            //test xóa thương hiệu đó
            bool status = false;
            var wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(20));
            var home = driver1.FindElements(By.ClassName("table-responsive"));
            //IWebElement element = driver1.FindElement(By.LinkText(txtBrand));
            foreach (var element in home)
            {
                string classAttributeValue = element.GetAttribute("class");
                string[] classes = classAttributeValue.Split(' ');
                foreach (string className in classes)
                {
                    if (className.Contains(txtBrand))
                    {
                        status = true;
                    }
                }
            }
            Assert.IsNotNull(status);
        }
        [Test]
        public void Test10()
        {
            ////link xóa bỏ để xóa thương hiệu vừa tạo
            IWebElement button = driver1.FindElement(By.CssSelector("a[href='/Admin/AdminBrands/Delete/38']"));
            if (button != null)
            {
                Actions actions = new Actions(driver1);
                actions.MoveToElement(button).Perform();
                button.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(button);
        }
        [Test]
        public void Test11()
        {
            //bấm btn xóa thương hiệu
            Actions actions = new Actions(driver1);
            IWebElement button = driver1.FindElement(By.XPath("/html/body/div/main/div[2]/form/div/input"));
            actions.MoveToElement(button).Click().Perform();
            Thread.Sleep(1000);
            Assert.IsNotNull(button);
            driver1.Quit();
        }

    }
}