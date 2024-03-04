using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace autotests_hw2
{
    internal class Program
    {
        static void Login(IWebDriver driver, string login, string password) {

            driver.Navigate().GoToUrl("https://b24-pfx119.bitrix24.ru/");

            var loginField = driver.FindElement(By.XPath("//input[@id='login']"));
            loginField.SendKeys(login);
            Thread.Sleep(1000);
            loginField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            var passwordField = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordField.SendKeys(password);
            Thread.Sleep(1000);
            passwordField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        static void CreateCalendarEvent(IWebDriver driver) {
            // переходим на страницу календаря
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var calendar = wait.Until(d => d.FindElement(By.Id("bx_left_menu_menu_calendar")));
            calendar.Click();

            var newEvent = wait.Until(d => d.FindElement(By.XPath("//button[@class='ui-btn-main']")));
            newEvent.Click();

            var title = wait.Until(d => d.FindElement(By.XPath("//input[@name='name']")));
            title.SendKeys("test event");

            // получаем дату с устройства и вводим в соответсвующее поле
            string[] dateTime = DateTime.Now.ToString().Split(" ");

            var dateField = driver.FindElement(By.XPath("//input[@name='date_from']"));
            dateField.Clear();
            dateField.SendKeys(dateTime[0]);

            // выбираем элемент выпадающего списка повторяемости
            var dropList = driver.FindElement(By.XPath("//*[@name='EVENT_RRULE[FREQ]']"));
            var select = new SelectElement(dropList);
            select.SelectByValue("WEEKLY");

            // сохраняем
            driver.FindElement(By.XPath("//button[@class='ui-btn ui-btn-success']")).Click();
        }


        static void Main(string[] args)
        {
            string login = Console.ReadLine();
            string password = Console.ReadLine();

            IWebDriver driver = new ChromeDriver();
            Login(driver, login, password);
            CreateCalendarEvent(driver);
        }
    }
}