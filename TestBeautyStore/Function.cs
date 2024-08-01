using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBeautyStore
{
    public class Function
    {
        IWebDriver driver = new ChromeDriver();
        public void BamLinkLogin(IWebDriver driver)
        {
            //bấm vào Khách hàng để hiển thị ra trang Login
            IWebElement btn = driver.FindElement(By.CssSelector("body > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > nav:nth-child(3) > ul:nth-child(1) > li:nth-child(6) > div:nth-child(1) > a:nth-child(1) > span:nth-child(2)"));
            btn.Click();
            Thread.Sleep(1000);
        }
        public void LoginAdmin(IWebDriver driver)
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
                Thread.Sleep(1000);
            }
        }
        public void Register(IWebDriver driver)
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
            Assert.Pass();
        }
        public void BamBtnMenu(IWebDriver driver)
        {
            //TestButtonMenu
            IWebElement button = driver.FindElement(By.CssSelector(".bi.bi-list.toggle-sidebar-btn"));
            if (button != null)
            {
                button.Click();
                Thread.Sleep(3000);
            }
        }
        public void BamQLSP(IWebDriver driver)
        {
            //Test Link QLSP
            IWebElement linkQLSP = driver.FindElement(By.CssSelector("body > aside:nth-child(2) > ul:nth-child(1) > li:nth-child(3) > a:nth-child(1) > span:nth-child(2)"));
            if (linkQLSP != null)
            {
                linkQLSP.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(linkQLSP);
        }
        public void BamQLTK(IWebDriver driver)
        {
            //Test Link ThongKe Quản lý Tài khoản
            IWebElement linkQLTK = driver.FindElement(By.XPath("//*[@id=\"sidebar-nav\"]/li[2]/a/span"));
            if (linkQLTK != null)
            {
                linkQLTK.Click();
                Thread.Sleep(5000);
            }
            Assert.IsNotNull(linkQLTK);
        }
        public void ThemSP(IWebDriver driver)
        {
            //test Link Thêm sản phẩm
            IWebElement themSP = driver.FindElement(By.PartialLinkText("Thêm sản phẩm"));
            if (themSP != null)
            {
                themSP.Click();
            }
            Assert.Pass();
        }
        public int TotalProducts(IWebDriver driver)
        {
            // Tính tổng số lượng sản phẩm
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("#main > div.table-responsive > table > tbody > tr"));
            int totalPro = rows.Count;
            return totalPro;
        }
        public void LinkChinhSua(IWebDriver driver)
        {
            //bấm chỉnh sửa trên mỗi sản phẩm
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Tìm tất cả các phần tử <a> chứa văn bản "Chỉnh sửa"
            var editLinks = driver.FindElements(By.XPath("//a[contains(text(), 'Chỉnh sửa')]"));
            IWebElement latestEditLink = editLinks.Last();
            // Khởi tạo Actions để thực hiện các hoạt động tương tác
            Actions actions = new Actions(driver);
            // Di chuyển con trỏ chuột đến liên kết của sản phẩm mới nhất
            actions.MoveToElement(latestEditLink).Perform();
            latestEditLink.Click();
        }
        public void LinkXoaBo(IWebDriver driver)
        {
            //bấm chữ xóa bỏ trên mỗi sản phẩm
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Tìm tất cả các phần tử <a> chứa văn bản "Chỉnh sửa"
            var editLinks = driver.FindElements(By.XPath("//a[contains(text(), 'Xóa bỏ')]"));
            IWebElement latestEditLink = editLinks.Last();
            // Khởi tạo Actions để thực hiện các hoạt động tương tác
            Actions actions = new Actions(driver);
            actions.MoveToElement(latestEditLink).Perform();
            latestEditLink.Click();
        }
        public void LinkChiTietDonHang(IWebDriver driver)
        {
            // Bấm vào chi tiết của mỗi đơn hàng
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/table")).Displayed);
            var lastCell = driver.FindElement(By.CssSelector("tbody tr:nth-child(2) td:nth-child(5)"));// Lấy ô cuối cùng của dòng đầu tiên
            var lastCellValue = lastCell.Text; // Lấy giá trị từ ô cuối cùng của dòng đầu tiên
            if (lastCellValue == "Chi tiết")
            {
                IWebElement click = driver.FindElement(By.LinkText(lastCellValue));
                Actions actions = new Actions(driver);
                actions.MoveToElement(click); Thread.Sleep(1000);
                actions.Click();//bấm vô xem chi tiết của đơn hàng mới nhất
                actions.Perform();
            }
        }








    }
}
