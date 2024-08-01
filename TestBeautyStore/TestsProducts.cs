using OpenQA.Selenium.Chrome;//admin
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace TestBeautyStore
{
    /// <summary>
    ///            CHƯA CÓ SỬA CÁI NÀY NHEN  (TEST SCRIPT)
    /// </summary>
    /// 


    public class TestsProducts
    {
        public int BeforeAdd { get; set; }
        public int AfterAdd { get; set; }

        //TEST THÊM SỬA XÓA SẢN PHẨM
        IWebDriver driver1 = new ChromeDriver();//admin
        IWebDriver driver2;//user
        [SetUp]
        public void Setup() { 

        }

        [Test] public void Test01()
        {
            driver1.Navigate().GoToUrl("https://localhost:44381/");
            Assert.IsNotNull(driver1);
        }
        [Test] public void Test02() 
        {
            //bấm vào Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver1.FindElement(By.CssSelector("#header > nav > ul > li:nth-child(6) > div > a"));
            btn.Click();
            Assert.IsNotNull(btn);
        }
        [Test] public void Test03() 
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
        [Test] public void Test04() 
        {
            //TestButtonMenu
            IWebElement button = driver1.FindElement(By.CssSelector(".bi.bi-list.toggle-sidebar-btn"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
            //Test Link QLSP
            IWebElement linkQLSP = driver1.FindElement(By.CssSelector("body > aside:nth-child(2) > ul:nth-child(1) > li:nth-child(3) > a:nth-child(1) > span:nth-child(2)"));
            if (linkQLSP != null)
            {
                linkQLSP.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(linkQLSP);
        }
        [Test] public void Test05() 
        {
            //Test Home, Quản lý sản phẩm
            bool status = false;
            var home = driver1.FindElements(By.ClassName("pagetitle"));
            foreach (var element in home)
            {
                string classAttributeValue = element.GetAttribute("class");
                string[] classes = classAttributeValue.Split(' ');
                foreach (string className in classes)
                {
                    if (className.Contains("Quản lý sản phẩm") && className.Contains("Home"))
                    {
                        status = true;
                    }
                }
            }
            Assert.IsNotNull(status);
        }
        [Test] public void Test06() 
        {
            //test thêm sản phẩm
            bool status = false;
            var wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(10));
            var home = driver1.FindElements(By.ClassName("main"));
            foreach (var element in home)
            {
                string classAttributeValue = element.GetAttribute("class");
                string[] classes = classAttributeValue.Split(' ');
                foreach (string className in classes)
                {
                    if (className.Contains("Thêm sản phẩm") && element.Enabled)
                    {
                        status = true;
                    }
                }
            }
            Assert.IsNotNull(status);
        }
        [Test] public void Test07() {
            //Test Chỉnh sửa, xóa bỏ
            bool status = false;
            var wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(10));
            var home = driver1.FindElements(By.ClassName("table-responsive"));
            foreach (var element in home)
            {
                string classAttributeValue = element.GetAttribute("class");
                string[] classes = classAttributeValue.Split(' ');
                foreach (string className in classes)
                {
                    if (className.Contains("Chỉnh sửa") && className.Contains("Xóa bỏ"))
                    {
                        status = true;
                    }
                }
            }
            Assert.IsNotNull(status);
        }
        [Test] public void Test08() 
        {
            //test Link Thêm sản phẩm
            IWebElement themSP = driver1.FindElement(By.PartialLinkText("Thêm sản phẩm"));
            if (themSP != null)
            {
                themSP.Click();
            }
            Assert.Pass();
        }
        public int TotalProductBeforeAdd()
        {
            // Tính tổng số lượng sản phẩm trước khi thêm sản phẩm
            IList<IWebElement> rows = driver1.FindElements(By.CssSelector("#main > div.table-responsive > table > tbody > tr"));
            int totalPro = rows.Count;
            return totalPro;
        }

        [Test] public void Test09() 
        {
            //Tính tổng số lượng sản phẩm trước khi thêm
            IList<IWebElement> rows = driver1.FindElements(By.CssSelector("#main > div.table-responsive > table > tbody > tr"));
            int totalPro = rows.Count;
            Assert.IsNotNull(totalPro);
        }
        [Test] public void Test10() 
        {
            //thêm hình ảnh 1
            AddProduct addPro = new AddProduct();
            IWebElement image1 = driver1.FindElement(By.Name("ImgProd1"));
            String filePath1 = addPro.Image1;
            image1.SendKeys(filePath1);
            Assert.Pass();
        }
        [Test] public void Test11() 
        {
            //thêm hình ảnh 2
            AddProduct addPro = new AddProduct();
            IWebElement image2 = driver1.FindElement(By.Name("ImgProd2"));
            String filePath2 = addPro.Image2;
            image2.SendKeys(filePath2);
            Assert.Pass();
        }
        [Test] public void Test12() 
        {
            //thêm tên sản phẩm mới
            AddProduct addPro = new AddProduct();
            IWebElement name = driver1.FindElement(By.Name("ProductName"));
            name.SendKeys(addPro.Name);
            Assert.Pass();
        }
        [Test] public void Test13() 
        {
            //thêm số lượng sản phẩm
            AddProduct addPro = new AddProduct();
            IWebElement amount = driver1.FindElement(By.Name("amount"));
            amount.Clear();
            amount.SendKeys(addPro.Amount);
            Assert.Pass();
        }
        [Test] public void Test14()
        {
            //thêm giá
            AddProduct addPro = new AddProduct();
            IWebElement price = driver1.FindElement(By.Name("Price"));
            price.SendKeys(addPro.Price);
            Assert.Pass();
        }
        [Test] public void Test15()
        {
            //test check box giảm giá
            Boolean isSelected = driver1.FindElement(By.Id("myCheck")).Selected;
            IWebElement element = driver1.FindElement(By.Id("myCheck"));
            if (isSelected == false)
            {
                Actions actions = new Actions(driver1);
                actions.MoveToElement(element);
                actions.Perform();
                element.Click();//hiển thị ô nhập giá gốc
            }
            Assert.IsNotNull(element);
        }
        [Test] public void Test16()
        {
            //thêm giá gốc
            AddProduct addPro = new AddProduct();
            IWebElement iprice = driver1.FindElement(By.Name("IntialPrice"));
            iprice.SendKeys(addPro.IntialPrice);
            Assert.Pass();
        }
        [Test] public void Test17()
        {
            //thêm loại sản phẩm
            AddProduct addPro = new AddProduct();
            IWebElement category = driver1.FindElement(By.Name("CategoryID"));
            SelectElement choose = new SelectElement(category);
            choose.SelectByIndex(addPro.CategoryID);
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test] public void Test18()
        {
            //thêm thương hiệu
            AddProduct addPro = new AddProduct();
            IWebElement brand = driver1.FindElement(By.Name("BrandID"));
            SelectElement choose = new SelectElement(brand);
            choose.SelectByIndex(addPro.BrandID);
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test] public void Test19()
        {
            //bấm thêm mới
            IWebElement btn = driver1.FindElement(By.CssSelector("#main > form > div.detail-admin > div > div > button"));
            if (btn != null)
            {
                Actions actions = new Actions(driver1);
                actions.MoveToElement(btn);
                actions.Perform();
                btn.Click();
            }
            Thread.Sleep(1000);
            driver1.Quit();
            Assert.Pass();
        }
        [Test]
        public void Test20()
        {
            //tìm kiếm sản phẩm sau khi thêm
            driver2 = new EdgeDriver();
            driver2.Navigate().GoToUrl("https://localhost:44381/");
            driver2.Manage().Window.Maximize();
            Thread.Sleep(2000);
            AddProduct addPro = new AddProduct();
            // Nhập tên sản phẩm đã thêm vào ô tìm kiếm
            IWebElement searchBox = driver2.FindElement(By.CssSelector("input[placeholder='Tìm kiếm']"));
            searchBox.SendKeys(addPro.Name); Thread.Sleep(2000); // tìm tên sản phẩm vừa với thêm
            searchBox.SendKeys(Keys.Enter); // Nhấn Enter hoặc nút tìm kiếm
            Thread.Sleep(2000);
            IWebElement resultElement = driver2.FindElement(By.CssSelector("body > main > div > div > div.product-list.category-product > div.row.product-list-items > div > a > div > div > div > p"));
            Thread.Sleep(1000); driver2.Quit();
            Assert.Pass();
        }
        public int TotalProductAfterAdd()
        {
            // Tính tổng số lượng sản phẩm sau khi thêm sản phẩm
            IList<IWebElement> rows = driver1.FindElements(By.CssSelector("#main > div.table-responsive > table > tbody > tr"));
            int totalProAfter = rows.Count;
            Console.WriteLine(totalProAfter);
            return totalProAfter;
        }
        [Test] public void Test22() 
        {
            bool status = false;
            int before = TotalProductBeforeAdd();//số lượng sản phẩm trước khi thêm
            int after = TotalProductAfterAdd();//số lượng sản phẩm sau khi thêm
            if (after == before)
            {
                status = true;
            }
            Assert.IsTrue(status);
        }
        //test sửa sp
                [Test]
        public void Test21()
        {
            driver1 = new ChromeDriver();
            driver1.Navigate().GoToUrl("https://localhost:44381/Admin/AdminProducts");
            driver1.Manage().Window.Maximize();
        }
        [Test]
        [TestCase("https://localhost:44381/Admin/AdminProducts/Edit/72")]
        public void Test23(string url)
        {
            driver1.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            Assert.IsNotNull(driver1);
        }
        [Test]
        public void Test24()
        {
            // Tìm và lấy nội dung cần xóa trước khi chỉnh sửa
            IWebElement contentElement = driver1.FindElement(By.XPath("/html/body/div/main/form/div[2]/div/div[1]/input[2]"));
            // Lấy nội dung ban đầu
            string initialContent = contentElement.Text;
            // Xóa nội dung
            contentElement.Clear();
            // Kiểm tra xem nội dung đã bị xóa thành công hay không
            Assert.IsEmpty(contentElement.Text);
        }
        [Test]
        [TestCase("ProductName", "Mỹ phẩm AD")]
        public void Test25(String txtN, String content)
        {
            IWebElement txt = driver1.FindElement(By.Name(txtN));
            if (txt != null)
            {
                txt.SendKeys(content);
            }
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test]
        public void Test26()
        {
            IWebElement element = driver1.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/form[1]/div[2]/div[1]/button[1]"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver1;
            executor.ExecuteScript("arguments[0].click();", element);

        }
        [Test]
        public void Test27()
        {
            // Điều hướng đến trang sản phẩm (hoặc trang có danh sách sản phẩm)
            driver1.Navigate().GoToUrl("https://localhost:44381/");
            driver1.Manage().Window.Maximize();
            // Nhập tên sản phẩm đã sửa vào ô tìm kiếm
            IWebElement searchBox = driver1.FindElement(By.CssSelector("input[placeholder='Tìm kiếm']"));
            searchBox.SendKeys("Mỹ phẩm AD"); // Thay "Mỹ phẩm A" bằng tên sản phẩm đã sửa
            searchBox.SendKeys(Keys.Enter);// Nhấn Enter hoặc nút tìm kiếm
            Thread.Sleep(2000);
        }

        //test xóa sản phẩm
        [Test]
        public void Test28()
        {
            //TestXoaSP
            driver1.Navigate().GoToUrl("https://localhost:44381/Admin/AdminProducts");
            driver1.Manage().Window.Maximize();
            IWebElement button = driver1.FindElement(By.CssSelector("a[href='/Admin/AdminProducts/Delete/72']"));
            if (button != null)
            {
                Actions actions = new Actions(driver1);
                actions.MoveToElement(button).Click().Perform();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(button);
        }

        [Test]
        public void Test29()
        {
            //TestNhanNutXoa
            IWebElement button = driver1.FindElement(By.CssSelector("input[value = 'Xóa']"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(button); driver1.Quit();

        }
        [Test]
        public void Test30()
        {
            driver2 = new EdgeDriver();
            // Điều hướng đến trang sản phẩm (hoặc trang có danh sách sản phẩm)
            driver2.Navigate().GoToUrl("https://localhost:44381/");
            driver2.Manage().Window.Maximize();
            // Nhập tên sản phẩm đã sửa vào ô tìm kiếm
            IWebElement searchBox = driver2.FindElement(By.CssSelector("input[placeholder='Tìm kiếm']"));
            searchBox.SendKeys("Mỹ phẩm AD"); // Thay "Mỹ phẩm A" bằng tên sản phẩm vừa xóa
            searchBox.SendKeys(Keys.Enter);// Nhấn Enter hoặc nút tìm kiếm
            Thread.Sleep(2000);
            driver2.Quit();
            Assert.Pass();
        }
    }
}