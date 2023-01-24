/*
------------------------------------------------------------------------------------------------
-- coding                                   | utf-8
-- Author                                   | Sergei Chernyahovsky
-- Site                                     | http://sergeicher.pro/
-- Favorite Quote                           | “Always code as if the guy who ends up
                                                maintaining your code will be a violent
                                                    psychopath who knows where you live”
-- Language                                 | C# 
-- WebDriver                                | Selenium
-- Site under test                          | https://ironscales.com/
-- Description                              | QA automation Junior position test - Selenium
------------------------------------------------------------------------------------------------
 */

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.DOMSnapshot;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;




namespace IronScales
{
    [TestFixture]
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Start()
        {
            Console.WriteLine("\nTest case started!\n");
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ironscales.com/");
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
            Console.WriteLine("\nTest case completed!\n");


        }

        [Test]
        public void Test1()
        {
            try
            {
                IWebElement solution = driver.FindElement(By.XPath("//span[text()='Solution']"));
                new Actions(driver).MoveToElement(solution).Perform();

                IWebElement by_plan = driver.FindElement(By.XPath("//ul/li/a[text()='By Plan']"));
                new Actions(driver).MoveToElement(by_plan).Perform();

                IList<IWebElement> actual_links = driver.FindElements(By.XPath("//*[@id=\"navbar_global\"]/div/ul[1]/li[1]/ul/li[2]/ul/li"));

                ArrayList links = new ArrayList();
                foreach (IWebElement element in actual_links)
                {
                    links.Add(element.Text);
                }
                foreach (var item in links)
                {
                    Console.WriteLine(item.ToString());
                }


                ArrayList expected = new ArrayList();
                expected.Add("Starter™");
                expected.Add("Email Protect™");
                expected.Add("Complete Protect™");

                Assert.AreEqual(expected, links, "The links don't match: ");
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(e.ToString());
            }

        }

        [Test]
        public void Test2()
        {
            try
            {
                IWebElement company = driver.FindElement(By.XPath("//span[text()='Company']"));
                new Actions(driver).MoveToElement(company).Perform();

                IWebElement careers = driver.FindElement(By.XPath("//a[text()='Careers']"));
                careers.Click();

                IWebElement job_openings = driver.FindElement(By.XPath("//a[text()='Job Openings']"));
                new Actions(driver).MoveToElement(job_openings).Perform();
                job_openings.Click();

                IWebElement qa_position = driver.FindElement(By.XPath("//h3/a[text()='QA Automation Engineer']"));
                qa_position.Click();

                IWebElement year_experience = driver.FindElement
                    (By.XPath("//*[@id='opportunityDetailView']/div[2]/div/div/div/div[2]/div[1]/div[3]/p/ul[2]/li[2]"));


                string test = year_experience.Text;
                char[] chars = test.ToCharArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < chars.Length; i++)
                {
                    if (char.IsDigit(chars[i]))
                    {
                        sb.Append(chars[i]);
                    }
                }
                Console.WriteLine(sb);

                int num = int.Parse(sb.ToString());

                Assert.Greater(num, 1, "The number is not grater than 1");
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(e.ToString());
            }

        }


        [Test]
        public void Test3()
        {
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight);");
                System.Threading.Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,400)");
                System.Threading.Thread.Sleep(1000);


                // Expected string 
                string expected = "LinkedIn In1_layer,YouTube2_layer,Twitter3_layer,Facebook F4_layer,Instagram5_layer";

                ReadOnlyCollection<IWebElement> actual_links = driver.FindElements(By.XPath("//a[@class='no-decoration']/i/*[name()='svg']/*[name()='g']"));

                string actual = "";
                foreach (var item in actual_links)
                {
                    actual += item.GetAttribute("id") + ",";
                }
                string result = actual.Remove(actual.Length - 1);
                Assert.AreEqual(expected, result);
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(e.ToString());
            }

        }

        [Test]
        public void Test4()
        {
            //implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight);");
                System.Threading.Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,400)");
                System.Threading.Thread.Sleep(1000);


                // LinkedIn
                IWebElement linkedin = driver.FindElement(By.XPath("//a[@class='no-decoration' and @href='https://www.linkedin.com/company/ironscales/']"));
                new Actions(driver).MoveToElement(linkedin).Perform();
                linkedin.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                System.Threading.Thread.Sleep(1000);
                IWebElement close_popup = driver.FindElement(By.XPath("//section/button[@aria-label='Dismiss']"));
                close_popup.Click();
                string expected_linkedin_url = "https://www.linkedin.com/company/ironscales/";
                string actual_linkedin_url = driver.Url;
                Assert.AreEqual(expected_linkedin_url, actual_linkedin_url);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);




                // YouTube
                IWebElement youtube = driver.FindElement(By.XPath("//a[@class='no-decoration' and @href='https://www.youtube.com/@ironscales4137']"));
                new Actions(driver).MoveToElement(youtube).Perform();
                youtube.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                System.Threading.Thread.Sleep(2000);
                string expected_youtube_url = "https://www.youtube.com/@ironscales4137";
                string actual_youtube_url = driver.Url;
                Assert.AreEqual(expected_youtube_url, actual_youtube_url);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);


                // Twitter
                IWebElement twitter = driver.FindElement(By.XPath("//a[@class='no-decoration' and @href='https://twitter.com/IRONSCALES']"));
                new Actions(driver).MoveToElement(twitter).Perform();
                twitter.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                System.Threading.Thread.Sleep(2000);
                string expected_twitter_url = "https://twitter.com/IRONSCALES";
                string actual_twitter_url = driver.Url;
                Assert.AreEqual(expected_twitter_url, actual_twitter_url);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);


                // Instagram
                IWebElement instagram = driver.FindElement(By.XPath("//a[@class='no-decoration' and @href='https://www.instagram.com/ironscalesltd/']"));
                new Actions(driver).MoveToElement(instagram).Perform();
                instagram.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                System.Threading.Thread.Sleep(2000);
                string expected_instagram_url = "https://www.instagram.com/ironscalesltd/";
                string actual_instagram_url = driver.Url;
                Assert.AreEqual(expected_instagram_url, actual_instagram_url);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);



                // Facebook
                IWebElement facebook = driver.FindElement(By.XPath("//a[@class='no-decoration' and @href='https://www.facebook.com/ironscalesltd/']"));
                new Actions(driver).MoveToElement(facebook).Perform();
                facebook.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                System.Threading.Thread.Sleep(2000);
                string expected_facebook_url = "https://www.facebook.com/ironscalesltd/";
                string actual_facebook_url = driver.Url;
                Assert.AreEqual(expected_facebook_url, actual_facebook_url);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);

                System.Threading.Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(e.ToString());
            }

        }
    }
}
