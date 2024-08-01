using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ClosedXML.Excel;
using System.Data.OleDb;
using System.Reflection;
using OfficeOpenXml;
using System.IO.Packaging;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestBeautyStore
{
    public class Test
    {
        public IWebDriver driver;
        Function function = new Function();

        [SetUp]
        public void Setup()
        {
            // Khởi tạo trình duyệt
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44381/");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Đóng trình duyệt sau khi tất cả các testcase đã hoàn thành
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [Test]
        public void TestLogin()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Login"];
                for (int i = 2; i <= 3; i++)
                {
                    driver.Navigate().GoToUrl("https://localhost:44381"); Thread.Sleep(1000);
                    function.BamLinkLogin(driver);
                    string username = worksheet.Cells[i, 1].Value.ToString();
                    string password = worksheet.Cells[i, 2].Value.ToString();
                    if (username != null && password != null)
                    {
                        IWebElement usernameInput = driver.FindElement(By.Name("UserEmail"));
                        usernameInput.SendKeys(username);

                        IWebElement passwordInput = driver.FindElement(By.Name("UserPassword"));
                        passwordInput.SendKeys(password);

                        IWebElement loginButton = driver.FindElement(By.ClassName("btn"));
                        loginButton.Click(); Thread.Sleep(3000);


                        ReadOnlyCollection<IWebElement> errorElements = driver.FindElements(By.CssSelector(".text-danger"));
                        if (errorElements.Count > 0)
                        {
                            worksheet.Cells[i, 6].Value = "Tên đăng nhập hoặc mật khẩu không đúng";
                            worksheet.Cells[i, 3].Value = " ";
                        }
                        else
                        {
                            worksheet.Cells[i, 6].Value = "Đăng nhập thành công";
                            ReadOnlyCollection<IWebElement> n = driver.FindElements(By.CssSelector("//span[@class='d-none d-md-block dropdown-toggle ps-2']"));
                            if (n.Count > 0)
                            {
                                username = n[0].Text;
                                worksheet.Cells[i, 3].Value = username;
                            }
                        }
                        driver.Quit();
                    }
                    package.Save();
                }
            }
        }

        [Test]
        public void TestRegister()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["RegisterUser"];
                for (int i = 2; i <= 6; i++)
                {
                    driver.Navigate().GoToUrl("https://localhost:44381/Users/SignUp");
                    string userName = worksheet.Cells[i, 1].Value.ToString();
                    string userEmail = worksheet.Cells[i, 2].Value.ToString();
                    string userPhone = worksheet.Cells[i, 3].Value.ToString();
                    string userPassword = worksheet.Cells[i, 4].Value.ToString();
                    string rePassword = worksheet.Cells[i, 5].Value.ToString();
                    if (userName != null)
                    {
                        IWebElement userNameInput = driver.FindElement(By.Name("userName"));
                        userNameInput.SendKeys(userName);

                        IWebElement userEmailInput = driver.FindElement(By.Name("userEmail"));
                        userEmailInput.SendKeys(userEmail);

                        IWebElement userPhoneInput = driver.FindElement(By.Name("phoneNumber"));
                        userPhoneInput.SendKeys(userPhone);

                        IWebElement userPasswordInput = driver.FindElement(By.Name("userPassword"));
                        userPasswordInput.SendKeys(userPassword);

                        IWebElement rePasswordInput = driver.FindElement(By.Name("rePassword"));
                        rePasswordInput.SendKeys(rePassword);

                        IWebElement button = driver.FindElement(By.CssSelector("div[class='btn-box'] button[type='submit']"));
                        button.Click();
                        Thread.Sleep(1000);

                        ReadOnlyCollection<IWebElement> errorElements = driver.FindElements(By.CssSelector(".text-danger"));
                        if (errorElements.Count > 0)
                        {
                            // Ghi "Đăng nhập không thành công" vào file Excel
                            worksheet.Cells[i, 7].Value = "Failed";
                        }
                        else
                        {
                            // Không có thông báo lỗi, ghi "Đã đăng nhập" vào file Excel
                            worksheet.Cells[i, 7].Value = "Passed";
                        }
                    }
                    package.Save();
                }
            }
        }

        [Test]
        //sửa tên
        public void TestChinhSuaDung()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                driver.Navigate().GoToUrl("https://localhost:44381/Admin/AdminHome");
                ExcelWorksheet worksheet = package.Workbook.Worksheets["ChinhSua"];
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        function.BamQLSP(driver);
                        function.LinkChinhSua(driver);
                        // Tìm và lấy nội dung cần xóa trước khi chỉnh sửa
                        IWebElement contentElement = driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/div/div[1]/input[2]"));
                        // Lấy nội dung ban đầu
                        string initialContent = contentElement.Text;
                        // Xóa nội dung
                        contentElement.Clear();
                        // Kiểm tra xem nội dung đã bị xóa thành công hay không
                        string productname = worksheet.Cells[i, 1].Value.ToString();
                        IWebElement productnameInput = driver.FindElement(By.Name("ProductName"));
                        productnameInput.SendKeys(productname);
                        
                        IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/form[1]/div[2]/div[1]/button[1]"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("arguments[0].click();", element);

                        ReadOnlyCollection<IWebElement> errorElements = driver.FindElements(By.CssSelector(".text-danger"));
                        if (errorElements.Count > 0)
                        {
                            // Ghi "Đăng nhập không thành công" vào file Excel
                            worksheet.Cells[i, 10].Value = "Failed";
                        }
                        else
                        {
                            // Không có thông báo lỗi, ghi "Đã đăng nhập" vào file Excel
                            worksheet.Cells[i, 10].Value = "Passed";
                        }
                    }
                    package.Save();
                }
            }


        }
        //sửa số lượng sp =0
        [Test]
        public void TestChinhSuaSai()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                driver.Navigate().GoToUrl("https://localhost:44381/Admin/AdminHome");
                ExcelWorksheet worksheet = package.Workbook.Worksheets["ChinhSua"];
                for (int i = 5; i <= 7; i++)
                {
                    int quantity = Convert.ToInt32(worksheet.Cells[i, 1].Value.ToString());

                    if (quantity == 0)
                    {
                        // Nếu quantity = 0, ghi "Failed" vào file Excel và lưu lại
                        worksheet.Cells[i, 2].Value = "Chỉnh sửa sai (số lượng sản phẩm > 0)";
                    }
                    else if (quantity >= 1)
                    {
                        function.BamQLSP(driver);
                        function.LinkChinhSua(driver);

                        // Tìm và lấy nội dung cần xóa trước khi chỉnh sửa
                        IWebElement contentElement = driver.FindElement(By.Name("amount"));
                        contentElement.SendKeys(contentElement.ToString());

                        // Lấy nội dung ban đầu
                        string initialContent = contentElement.Text;

                        // Xóa nội dung
                        contentElement.Clear();

                        // Nhập giá trị quantity vào trường nhập liệu trên trang web
                        IWebElement quantityInput = driver.FindElement(By.Name("amount"));
                        quantityInput.SendKeys(quantity.ToString());

                        IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/form[1]/div[2]/div[1]/button[1]"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        worksheet.Cells[i, 2].Value = "Chỉnh sửa thành công";
                    }
                    package.Save();
                }

            }
        }
        [Test]
        public void XoaSai()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                driver.Navigate().GoToUrl("https://localhost:44381/Admin/AdminHome");
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Xoa"];
                {
                    {
                        function.BamQLSP(driver);
                        string productname = worksheet.Cells[1, 1].Value.ToString();
                        function.LinkXoaBo(driver);
                        IWebElement button = driver.FindElement(By.CssSelector("input[value = 'Xóa']"));
                        button.Click();

                        ReadOnlyCollection<IWebElement> errorElements = driver.FindElements(By.CssSelector(".text-danger"));
                        if (errorElements.Count > 0)
                        {
                            // Ghi "Đăng nhập không thành công" vào file Excel
                            worksheet.Cells[1, 2].Value = "Failed";
                        }
                        else
                        {
                            // Không có thông báo lỗi, ghi "Đã đăng nhập" vào file Excel
                            worksheet.Cells[1, 2].Value = "Passed";
                        }
                    }
                    package.Save();
                }

            }
        }

        [Test]
        public void XoaDung()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Xoa"];
                string productName = worksheet.Cells[2, 1].Value.ToString();

                // Kiểm tra xem sản phẩm có tồn tại trên trang web không
                bool productExists = KiemTraTonTaiSanPham(driver, productName);
                if (!productExists)
                {
                    // Nếu sản phẩm không tồn tại, ghi "Failed" vào file Excel và kết thúc
                    worksheet.Cells[2, 2].Value = "Failed";
                    package.Save();
                    return;
                }
                // Gọi hàm BamQLSP(driver) chỉ khi sản phẩm tồn tại
                function.BamQLSP(driver);

                function.LinkXoaBo(driver);
                IWebElement button = driver.FindElement(By.CssSelector("input[value = 'Xóa']"));
                button.Click();

                ReadOnlyCollection<IWebElement> errorElements = driver.FindElements(By.CssSelector(".text-danger"));
                if (errorElements.Count > 0)
                {
                    // Ghi "Đăng nhập không thành công" vào file Excel
                    worksheet.Cells[2, 2].Value = "Failed";
                }
                else
                {
                    // Không có thông báo lỗi, ghi "Đã đăng nhập" vào file Excel
                    worksheet.Cells[2, 2].Value = "Passed";
                }

                package.Save();
            }
        }
        public bool KiemTraTonTaiSanPham(IWebDriver driver, string productName)
        {
            // Tìm tất cả các sản phẩm trên trang web
            ReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.XPath("//a[contains(text(), '" + productName + "')]"));
            return productElements.Count > 0;
        }



        [Test]
        public void TestThemSanPham()
        {
            string filePath = "D:\\BDCLPM LT\\TestBeautyStore.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets["AddProduct"];
                {
                    driver.Navigate().GoToUrl("https://localhost:44381/Admin/AdminProducts");

                    for (int i = 2; i <= 3; i++)
                    {
                        Thread.Sleep(1000);
                        int before = function.TotalProducts(driver);

                        driver.FindElement(By.PartialLinkText("Thêm sản phẩm")).Click(); Thread.Sleep(1000);
                        //thêm hình ảnh 1
                        string i1 = worksheet.Cells[i, 4].Value.ToString();
                        IWebElement image1 = driver.FindElement(By.Name("ImgProd1"));
                        String filePath1 = @"D:\BDCLPM LT\WebMTK-main\BeautyStore\image\" + i1;
                        image1.SendKeys(filePath1); Thread.Sleep(1000);

                        //thêm hình ảnh 2
                        string i2 = worksheet.Cells[i, 5].Value.ToString();
                        IWebElement image2 = driver.FindElement(By.Name("ImgProd2"));
                        String filePath2 = @"D:\BDCLPM LT\WebMTK-main\BeautyStore\image\" + i2;
                        image2.SendKeys(filePath2); Thread.Sleep(1000);

                        //thêm tên
                        string productname = worksheet.Cells[i, 1].Value.ToString();
                        IWebElement productnameInput = driver.FindElement(By.Name("ProductName"));
                        productnameInput.SendKeys(productname); Thread.Sleep(1000);

                        //thêm số lượng
                        int quantity = Convert.ToInt32(worksheet.Cells[i, 8].Value.ToString());
                        IWebElement quantityInput = driver.FindElement(By.Name("amount"));
                        quantityInput.Clear();
                        quantityInput.SendKeys(quantity.ToString()); Thread.Sleep(1000);

                        //thêm giá
                        int price = Convert.ToInt32(worksheet.Cells[i, 3].Value.ToString());
                        IWebElement priceInput = driver.FindElement(By.Name("Price"));
                        priceInput.SendKeys(price.ToString()); Thread.Sleep(1000);

                        //check box giảm giá
                        Boolean isSelected = driver.FindElement(By.Id("myCheck")).Selected;
                        IWebElement element = driver.FindElement(By.Id("myCheck")); Thread.Sleep(1000);
                        if (isSelected == false)
                        {
                            Actions actions = new Actions(driver);
                            actions.MoveToElement(element);
                            actions.Perform();
                            element.Click();//hiển thị ô nhập giá gốc
                        }

                        //thêm giảm giá
                        int iprice = Convert.ToInt32(worksheet.Cells[i, 2].Value.ToString());
                        IWebElement ipriceInput = driver.FindElement(By.Name("IntialPrice"));
                        ipriceInput.SendKeys(iprice.ToString()); Thread.Sleep(1000);

                        string categoryId = worksheet.Cells[i, 7].Value.ToString(); //chọn tên catagory
                        SelectElement selectCate = new SelectElement(driver.FindElement(By.Name("CategoryID")));
                        // Sử dụng SelectByValue để chọn tùy chọn dựa trên giá trị
                        selectCate.SelectByText(categoryId);

                        string brandId = worksheet.Cells[i, 6].Value.ToString(); //chọn tên thương hiệu
                        SelectElement selectBrand = new SelectElement(driver.FindElement(By.Name("BrandID")));
                        selectBrand.SelectByText(brandId); Thread.Sleep(1000);

                        //bấm thêm mới
                        IWebElement btn = driver.FindElement(By.CssSelector("#main > form > div.detail-admin > div > div > button"));
                        if (btn != null)
                        {
                            Actions actions = new Actions(driver);
                            actions.MoveToElement(btn);
                            actions.Perform();
                            btn.Click();
                        }
                        Thread.Sleep(2000);
                        int after = function.TotalProducts(driver);

                        if (after == before + 1)
                        {
                            worksheet.Cells[i, 10].Value = "Thêm sản phẩm thành công";
                        }
                        else
                        {
                            worksheet.Cells[i, 10].Value = "Lỗi";
                        }
                    }
                    package.Save();
                }
            }
        }









    }

}

