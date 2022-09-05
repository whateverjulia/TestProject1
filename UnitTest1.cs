using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class Tests
    {
      IWebDriver webDriver;
      
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://avic.ua/ua");
        }
        [TearDown]
        public void Teardown()
        {
            webDriver.Quit();
        }

        [Test]
        public void Test1()
        {
            webDriver.Manage().Window.Maximize();

            IWebElement searchBox = webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div/div[3]/form/input"));
            IWebElement searchButton = webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div/div[3]/form/button[2]"));

            searchBox.SendKeys("iphone 13" + Keys.Enter);

            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div/div[3]/div[3]/div/div[3]/a/div[2]"));
            Assert.That(element.Text, Is.EqualTo("Смартфон Apple iPhone 13 128GB Blue (MLPK3)"));
        }


        [Test]
        
        public void Test2()
        {
            webDriver.Manage().Window.Maximize();
            IWebElement link = webDriver.FindElement(By.XPath("/html/body/div[1]/main/section[2]/div/div[2]/div[2]/div[1]/div[2]/div/div/ul/li[1]/a"));
            link.Click();
            

            IWebElement element1 = webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div/div[1]/div[1]"));
            Assert.That(element1.Text, Is.Not.EqualTo("Смартфони"));

        }

        [Test]
        public void Test3()
        {
            webDriver.Manage().Window.Maximize();

            IWebElement element1 = webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div/div[4]/a[2]/div/div[1]"));
            Assert.That(element1.Text, Is.EqualTo("0"));

            IWebElement link1 = webDriver.FindElement(By.XPath("/html/body/div[1]/main/section[2]/div/div[2]/div[1]/div[1]/div[2]/a/div[1]/div[1]"));
            link1.Click();
            IWebElement link2 = webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/main/section[2]/div/div[2]/div[2]/div/div[1]/div[2]/a[1]"));
            link2.Click();

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Продовжити покупки')]")));
            webDriver.FindElement(By.XPath("//a[contains(text(),'Продовжити покупки')]")).Click();

            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//a[contains(text(),'Головна')]")).Click();
            
            Thread.Sleep(1000);
            IWebElement element2 = webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div/div[4]/a[2]/div/div[1]"));
            Assert.That(element2.Text, Is.EqualTo("1"));
        }
    }
}