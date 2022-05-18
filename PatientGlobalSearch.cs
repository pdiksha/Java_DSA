using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace MMDTesting
{
    [TestFixture(typeof(ChromeDriver))]

    public class PatientGlobalSearch<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        static IWebDriver driver;

        /// <summary>
        /// This function is used to initialize the driver
        /// </summary>
        public void SetUp()
        {
          
            
                PageObjects.strCurrentBrowser = "Chrome";
                driver = new ChromeDriver();
            

            //maximize Browser
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// This function is used to navigate to the URL
        /// </summary>
        public void goToHomePage()
        {
            SetUp();
            driver.Navigate().GoToUrl("https://cernprpwebdev01.northamerica.cerner.net/EA511Test/#/");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// This function is used for the general login purpose
        /// </summary>
        /// <param name="TestCaseName"></param>
        public void login(string TestCaseName)
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues(TestCaseName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(2000);
        }

        public void logoff()
        {
            driver.FindElement(PageObjects.homepageLogoff).Click();
            Thread.Sleep(2000);
        }

        public void SetConfigurationCglobal(string val)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as ISI System Administrator
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Global Search Required Parameters Option");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys(val);

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();
        }

        public void SetRoleDemoPracticeAdmin()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as Demo Practice Administrator
            Thread.Sleep(4000);
        }

        [Test]
        public void GlobalSearchforDifferentRoles()
        {
            goToHomePage();
            Thread.Sleep(2000);
            Array arrInput = Excelinput.fnGetTestInputValues("GlobalSearchforDifferentRoles");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(2000);

            string[] strRoles = new string[4];
            strRoles[0] = arrInput.GetValue(6).ToString();
            strRoles[1] = arrInput.GetValue(8).ToString();
            strRoles[2] = arrInput.GetValue(10).ToString();
            strRoles[3] = arrInput.GetValue(12).ToString();

            int SearchSuccessful = 0;

            foreach (string str in strRoles)
            {
                Thread.Sleep(2000);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
                Thread.Sleep(5000);
                driver.FindElement(PageObjects.changeRole).Click();
                Thread.Sleep(3000);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='" + str + "']")));
                driver.FindElement(By.XPath("//a[text()='" + str + "']")).Click();
                Thread.Sleep(3000);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
                Thread.Sleep(4000);
                driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
                Thread.Sleep(3000);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
                driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
                Thread.Sleep(3000);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
                Thread.Sleep(3000);
                driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientLastName));
                driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(14).ToString());
                driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(16).ToString());
                driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(18).ToString());

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchButton));

                driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
                Thread.Sleep(3000);

                //To enter the comment and close the window
                if(IsWebElementPresent(driver, By.XPath("//b[contains(text(),'OTHER')]")))
                {
                    driver.FindElement(By.XPath("//b[contains(text(),'OTHER')]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).Click();
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-if='multiline && !showSpan']")));
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).SendKeys("Testing");
                    driver.FindElement(By.XPath("//span[text()='OK']")).Click();
                    Thread.Sleep(2000);
                }

                if (driver.FindElements(PageObjects.PatientSearchDataTable).Count > 0)
                {
                    SearchSuccessful++;
                }
                
            }

            MMDScreenshot.UpdateScreenshot(driver, "GlobalSearchforDifferentRoles");

            //To validate the row count is considered in each role patient serach module. 
            if (SearchSuccessful >= 4)
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchforDifferentRoles", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchforDifferentRoles", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        /// <summary>
        /// This test case is to validate the patient search filters
        /// </summary>
        [Test]
        public void GlobalSearchValidateFilters()
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("GlobalSearchValidateFilters");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.ISISystemAdministratorRole));
            driver.FindElement(PageObjects.ISISystemAdministratorRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();

            //To Chcekc whether filters are displayed or not
            int Filters = 0;

            //1 Last Name
            if (IsWebElementPresent(driver, PageObjects.PatientSearchPatientLastName))
            {
                Filters++;
            }

            //2 First Name
            if (IsWebElementPresent(driver, PageObjects.PatientSearchPatientFirstName))
            {
                Filters++;
            }

            //3 DOB
            if (IsWebElementPresent(driver, PageObjects.PatientSearchDOB))
            {
                Filters++;
            }

            //4 SSN
            if (IsWebElementPresent(driver, PageObjects.PatientSearchSSN))
            {
                Filters++;
            }

            //5 Gender
            if (IsWebElementPresent(driver, PageObjects.PatientSearchGender))
            {
                Filters++;
            }

            //6 Zip code
            if (IsWebElementPresent(driver, PageObjects.PatientSearchZIP))
            {
                Filters++;
            }

            //7 MRN
            if (IsWebElementPresent(driver, PageObjects.PatientSearchMRN))
            {
                Filters++;
            }

            // 8 Last Name text
            if (driver.FindElement(PageObjects.PatientSearchPatientLastName).GetAttribute("placeholder") == "Min 2 chars")
            {
                Filters++;
            }

            //9 DOB text
            if (driver.FindElement(PageObjects.PatientSearchDOB).GetAttribute("placeholder") == "mm/dd/yyyy")
            {
                Filters++;
            }

            //10 MRN text
            if (driver.FindElement(PageObjects.PatientSearchMRN).GetAttribute("placeholder") == "Min 3 chars")
            {
                Filters++;
            }

            //11 SSN text
            if (driver.FindElement(PageObjects.PatientSearchSSN).GetAttribute("placeholder") == "Last 4 chars")
            {
                Filters++;
            }

            //12 clear button
            if (IsWebElementPresent(driver, PageObjects.PatientSearchClearButton))
            {
                Filters++;
            }

            //13 search button
            if (IsWebElementPresent(driver, PageObjects.PatientSearchSearchButton))
            {
                Filters++;
            }

            //14 Begins wth text above Last Name
            if (IsWebElementPresent(driver, By.XPath("//span[text()='B']//following-sibling::text-field[@uid='patient-search-last-name-filter']")))
            {
                Filters++;
            }

            //15 Begin with text above First Name
            if (IsWebElementPresent(driver, By.XPath("//span[text()='B']//following-sibling::text-field[@uid='patient-search-first-name-filter']")))
            {
                Filters++;
            }

            //16 Caontains text above MRN
            if (IsWebElementPresent(driver, By.XPath("//span[text()='C']//following-sibling::text-field[@label='Patient MRN']")))
            {
                Filters++;
            }

            //17 Help button
            try
            {
                List<IWebElement> PatientSearchHelpButton = new List<IWebElement>();
                PatientSearchHelpButton = driver.FindElements(By.XPath("//i[@class='fa fa-question-circle']")).ToList();

                if (PatientSearchHelpButton[1].Displayed)
                {
                    Filters++;
                }
            }
            catch(Exception ex)
            {

            }
            
            //18 Config timezone labe at bottom of the page
            if (IsWebElementPresent(driver, By.XPath("//div[contains(text(),'* All times in Eastern Standard Time')]")))
            {
                Filters++;
            }

            MMDScreenshot.UpdateScreenshot(driver, "GlobalSearchValidateFilters");
            Thread.Sleep(2000);

            //To validate the total count of filters are taken that should be displayed in the patient search screen
            if (Filters >= 18)
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchValidateFilters", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchValidateFilters", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void GlobalSearchValidateLastNameMinChar()
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("GlobalSearchValidateLastNameMinChar");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.ISISystemAdministratorRole));
            driver.FindElement(PageObjects.ISISystemAdministratorRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString().Substring(0,1));
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());

            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "GlobalSearchValidateLastNameMinChar");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//p[@id='patient-search-last-name-filter-error']")).Displayed)
            {
                driver.FindElement(PageObjects.PatientSearchClearButton).Click();
                driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
                driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
                driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
                Thread.Sleep(2000);

                if (IsWebElementPresent(driver, By.XPath("//b[contains(text(),'OTHER')]")))
                {
                    driver.FindElement(By.XPath("//b[contains(text(),'OTHER')]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).Click();
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-if='multiline && !showSpan']")));
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).SendKeys("Testing");
                    driver.FindElement(By.XPath("//span[text()='OK']")).Click();
                    Thread.Sleep(2000);
                }

                if (driver.FindElements(PageObjects.PatientSearchDataTable).Count > 0)
                {
                    Excelinput.fnUpdateResultinExcel("GlobalSearchValidateLastNameMinChar", "Pass");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Pass();
                }
                else
                {
                    Excelinput.fnUpdateResultinExcel("GlobalSearchValidateLastNameMinChar", "Fail");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Fail();
                }
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchValidateLastNameMinChar", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void GlobalSearchValidateMRNMinChar()
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("GlobalSearchValidateMRNMinChar");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.ISISystemAdministratorRole));
            driver.FindElement(PageObjects.ISISystemAdministratorRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(8).ToString().Substring(0, 2));

            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "GlobalSearchValidateMRNMinChar");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//p[contains(text(),'Please provide at least the first 3 characters of the Patient MRN.')]")).Displayed)
            {
                driver.FindElement(PageObjects.PatientSearchClearButton).Click();
                driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
                driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(8).ToString().Substring(0, 3));
                driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
                Thread.Sleep(2000);

                if (IsWebElementPresent(driver, By.XPath("//b[contains(text(),'OTHER')]")))
                {
                    driver.FindElement(By.XPath("//b[contains(text(),'OTHER')]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).Click();
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-if='multiline && !showSpan']")));
                    driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).SendKeys("Testing");
                    driver.FindElement(By.XPath("//span[text()='OK']")).Click();
                    Thread.Sleep(2000);
                }

                if (driver.FindElements(PageObjects.PatientSearchDataTable).Count > 0)
                {

                    driver.FindElement(PageObjects.PatientSearchClearButton).Click();
                    driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
                    driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(8).ToString());
                    driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
                    Thread.Sleep(2000);

                    if (IsWebElementPresent(driver, By.XPath("//b[contains(text(),'OTHER')]")))
                    {
                        driver.FindElement(By.XPath("//b[contains(text(),'OTHER')]")).Click();
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).Click();
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-if='multiline && !showSpan']")));
                        driver.FindElement(By.XPath("//textarea[@ng-if='multiline && !showSpan']")).SendKeys("Testing");
                        driver.FindElement(By.XPath("//span[text()='OK']")).Click();
                        Thread.Sleep(2000);
                    }

                    if (driver.FindElements(PageObjects.PatientSearchDataTable).Count > 0)
                    {
                        Excelinput.fnUpdateResultinExcel("GlobalSearchValidateMRNMinChar", "Pass");
                        logoff();
                        Thread.Sleep(2000);
                        Assert.Pass();
                    }
                    else
                    {
                        Excelinput.fnUpdateResultinExcel("GlobalSearchValidateMRNMinChar", "Fail");
                        logoff();
                        Thread.Sleep(2000);
                        Assert.Fail();
                    }
                }
                else
                {
                    Excelinput.fnUpdateResultinExcel("GlobalSearchValidateMRNMinChar", "Fail");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Fail();
                }
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("GlobalSearchValidateMRNMinChar", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void TestGlobalSearchAccess_ValidUser()
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchAccess_ValidUser");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchAccess_ValidUser");
            Thread.Sleep(2000);

            if (driver.FindElement(PageObjects.PatientSearchPatientLastName).Displayed)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchAccess_ValidUser", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchAccess_ValidUser", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void TestGlobalSearchAccess_InValidUser()
        {
            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchAccess_InValidUser");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);
                        

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchAccess_InValidUser");
            Thread.Sleep(2000);

            if (IsWebElementPresent(driver, By.XPath("//div[contains(text(),'You are not authorized to access this page. Please contact your System Administrator.')]")))
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchAccess_InValidUser", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchAccess_InValidUser", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void TestGlobalSearchValidateSystemSettings()
        {
            bool option1 = false;//C-Global Search Required Parameters Option == 1
            bool option2 = false;//C-Global Search Required Parameters Option == 2
            bool option3 = false;//C-Global Search Required Parameters Option == 3
            bool option4 = false;//C-Global Search Required Parameters Option == 4 or any value

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateSystemSettings");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //option 1 - C-Global Search Required Parameters Option == 1

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Global Search Required Parameters Option");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("1");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchValidateSystemSettings");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//*[@id='patient-search-last-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-cond-required']")).Displayed)//DOB optional
                {
                    if (driver.FindElement(By.XPath("//*[@title='Patient MRN']//ancestor::div[@class='mmd-cond-required']")).Displayed)//MRN Optional
                    {
                        if (driver.FindElement(By.XPath("//*[@title='Patient SSN']//ancestor::div[@class='2 mmd-cond-required']")).Displayed)//SSN optional
                        {
                            option1 = true;
                        }
                    }
                }
            }

            //option 2 - C-Global Search Required Parameters Option == 2

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Global Search Required Parameters Option");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("2");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchValidateSystemSettings");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//*[@id='patient-search-last-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-required']")).Displayed)//DOB optional
                {
                    if (driver.FindElement(By.XPath("//*[@id='patient-search-first-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//MRN Optional
                    {
                        option2 = true;
                    }
                }
            }

            //option 3 - C-Global Search Required Parameters Option == 3

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Global Search Required Parameters Option");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("3");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchValidateSystemSettings");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//*[@id='patient-search-last-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-required']")).Displayed)//DOB optional
                {
                    if (driver.FindElement(By.XPath("//*[@id='patient-search-first-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//MRN Optional
                    {
                        if (driver.FindElement(By.XPath("//*[@id='patient-search-gender-filter']//ancestor::div[@class='mmd-required']")).Displayed)//MRN Optional
                        {
                            option3 = true;
                        }
                    }
                }
            }

            //option 4 - C-Global Search Required Parameters Option == 4

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();//to change the role from ISI Admin to Demo practice admin
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Global Search Required Parameters Option");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("4");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.AssociatedCardiologistsV29PPracticeAdministratorRole).Click();// To select the role as demo pract admin
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            MMDScreenshot.UpdateScreenshot(driver, "TestGlobalSearchValidateSystemSettings");
            Thread.Sleep(2000);

            if (driver.FindElement(By.XPath("//*[@id='patient-search-last-name-filter']//ancestor::div[@class='mmd-required']")).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-cond-required']")).Displayed)//DOB optional
                {
                    if (driver.FindElement(By.XPath("//*[@title='Patient MRN']//ancestor::div[@class='mmd-cond-required']")).Displayed)//MRN Optional
                    {
                        if (driver.FindElement(By.XPath("//*[@title='Patient SSN']//ancestor::div[@class='2 mmd-cond-required']")).Displayed)//SSN optional
                        {
                            option4 = true;
                        }
                    }
                }
            }

            if(option1 && option2 && option3 && option4)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateSystemSettings", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateSystemSettings", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }


        [Test]
        public void TestGlobalSearchValidateConfiguration1()
        {
            bool option1 = false; //Sets to true when C-Global Search Required Parameters Option == 1 

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration1");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //Validate if the required and optionally required fields are identified on UI
            if (driver.FindElement(PageObjects.patientLNameRequired).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(PageObjects.patientDobCRequired).Displayed)//DOB optional
                {
                    if (driver.FindElement(PageObjects.patientMRNCRequired).Displayed)//MRN Optional
                    {
                        if (driver.FindElement(PageObjects.pSSNCReuired).Displayed)//SSN optional
                        {
                            option1 = true;
                        }
                    }
                }
            }

            //Test is passed or failed 
            if (option1)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }


        }

        [Test]
        public void TestGlobalSearchValidateConfiguration2()
        {
            bool option1 = false;//Sets to true when C-Global Search Required Parameters Option == 2 

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration2");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 2
            SetConfigurationCglobal("2");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //Validate if the required and optionally required fields are identified on UI
            if (driver.FindElement(PageObjects.patientLNameRequired).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(PageObjects.patientDobRequired).Displayed)//DOB Mandatory
                {
                    if (driver.FindElement(PageObjects.patientFNameRequired).Displayed)//First Name Mandatory
                    {
                        option1 = true;
                    }
                }
            }

            //Test is passed or failed
            if (option1)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }

        }

        [Test]
        public void TestGlobalSearchValidateConfiguration3()
        {
            bool option1 = false;//Sets to true when C-Global Search Required Parameters Option == 3 

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration3");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 3
            SetConfigurationCglobal("3");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //Validate if the required and optionally required fields are identified on UI
            if (driver.FindElement(PageObjects.patientLNameRequired).Displayed)//Last Name Mandatory
            {
                if (driver.FindElement(PageObjects.patientDobRequired).Displayed)//DOB Mandatory
                {
                    if (driver.FindElement(PageObjects.patientFNameRequired).Displayed)//First Name Mandatory
                    {
                        if (driver.FindElement(PageObjects.patinetGenderRequired).Displayed)//Gender Mandatory
                        {
                            option1 = true;
                        }
                    }
                }
            }

            //Test is passed or failed
            if (option1)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration3", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration3", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }



        }

        [Test]
        public void TestGlobalSearchValidateConfiguration1PatientRecord()
        {
            bool option1 = false; //Sets to true if Patient Records are returned for Configuration = 1

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration1PatientRecord");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            //Hitting cancel or close will abort the search
            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            //Hit on Search 
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //To check if the Actions DropDown is displayed or not
            if (driver.FindElement(PageObjects.PatientSearchActionButton).Displayed)
            {
                option1 = true;
            }
            else
            {
                option1 = false;

            }

            //Test is passed or failed 
            if (option1==true)
             {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1PatientRecord", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
             }
            else
             {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1PatientRecord", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
             }
                        


        }

        [Test]
        public void TestGlobalSearchValidateConfiguration2PatientRecord()
        {
            bool option1 = false; //Sets to true if Patient Records are returned for Configuration = 2

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration2PatientRecord");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 2
            SetConfigurationCglobal("2");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            //Hitting cancel or close will abort the search
            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            //Hit on Search
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //To check if the Actions DropDown is displayed or not
            if (driver.FindElement(PageObjects.PatientSearchActionButton).Displayed)
            {
                option1 = true;
            }
            else
            {
                option1 = false;

            }

            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2PatientRecord", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2PatientRecord", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }



        }

        [Test]
        public void TestGlobalSearchValidateConfiguration3PatientRecord()
        {
            bool option1 = false; //Sets to true if Patient Records are returned for Configuration = 3

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration3PatientRecord");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 3
            SetConfigurationCglobal("3");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            //Hitting cancel or close will abort the search
            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            //Hit on Search
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //To check if the Actions DropDown is displayed or not
            if (driver.FindElement(PageObjects.PatientSearchActionButton).Displayed)
            {
                option1 = true;
            }
            else
            {
                option1 = false;

            }

            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration3PatientRecord", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration3PatientRecord", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }



        }

        [Test]
        public void TestGlobalSearchValidateConfiguration1SearchEntry()
        {
            bool option1 = false; //Set to true if only last name is entered and a validation error is displayed
            bool option2 = false; //Set to true when last name and dob is entered and search is allowed
            bool option3 = false; //Set to true when last name and SSN is entered and search is allowed
            bool option4 = false; //Set to true if last name and zip code is entered and a validation error is displayed
            bool option5 = false; //Set to true when last name, MRN and zip code is entered and search is allowed
            bool option8 = false; //Set to true when last name, zip code and gender is entered and a validaton error is displayed

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration1SearchEntry");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.DemoPracticeAdministrator));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.DemoPracticeAdministrator).Click();// To select the role as Demo Practice Administrator
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //1. Test with only Last Name
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            option1 = IsWebElementPresent(driver, PageObjects.ConditionalRequiredError);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();

            //2. Last Name and DOB
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option2 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();

            //3. Last Name and SSN
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchSSN).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option3 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchSSN).Clear();

            //4. Last Name and Zip Code
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchZIP).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            option4 = IsWebElementPresent(driver, PageObjects.ConditionalRequiredError);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchZIP).Clear();

            //5. Last Name, MRN and Zip Code
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchZIP).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(14).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option5 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchZIP).Clear();
            driver.FindElement(PageObjects.PatientSearchMRN).Clear();

            //8. Last Name, Zip code and Gender
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchZIP).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys(arrInput.GetValue(16).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            option8 = IsWebElementPresent(driver, PageObjects.ConditionalRequiredError);

            //Test is passed or failed
            if (option1 == true && option2== true && option3 == true && option4 == true && option5 == true && option8 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1SearchEntry", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration1SearchEntry", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }


        }

        [Test]
        public void TestGlobalSearchValidateConfiguration2SearchEntry()
        {
            bool option1 = false; //Set to true when last name, first name and dob is entered and search is allowed
            bool option2 = false; //Set to true when last name, first name, dob and SSN is entered and search is allowed
            bool option3 = false; //Set to true when last name, first name MRN and Zip Code is entered and search is allowed

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration2SearchEntry");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 2
            SetConfigurationCglobal("2");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //1. Test with Last Name, First Name, DOB
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option1 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();

            //2. Test with Last Name, First Name, DOB and SSN
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSSN).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option2 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchSSN).Clear();

            //3. Test with Last Name, First Name, DOB, MRN and Zip Code
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchZIP).SendKeys(arrInput.GetValue(14).ToString());
            driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(16).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option3 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchZIP).Clear();
            driver.FindElement(PageObjects.PatientSearchMRN).Clear();

            //Test is passed or failed
            if (option1 == true && option2 == true && option3 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2SearchEntry", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2SearchEntry", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }


        }

        [Test]
        public void TestGlobalSearchValidateConfiguration3SearchEntry()
        {
            bool option1 = false; //Set to true when last name, first name dob and gender is entered and search is allowed
            bool option2 = false; //Set to true when last name, first name, gender, dob and SSN is entered and search is allowed
            bool option3 = false; //Set to true when last name, first name, gender, MRN and zipcode is entered and search is allowed

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchValidateConfiguration3SearchEntry");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 3
            SetConfigurationCglobal("3");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //1. Test with Last Name, First Name, DOB and Gender
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys(arrInput.GetValue(12).ToString()); 
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option1 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys("Select");

            //2. Test with Last Name, First Name, DOB, Gender and SSN
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchSSN).SendKeys(arrInput.GetValue(14).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option2 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchSSN).Clear();
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys("Select");

            //3. Test with Last Name, First Name, DOB, Gender, MRN and Zip Code
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchZIP).SendKeys(arrInput.GetValue(16).ToString());
            driver.FindElement(PageObjects.PatientSearchMRN).SendKeys(arrInput.GetValue(18).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            if (driver.FindElement(PageObjects.otheroption).Displayed)
            {
                option3 = true;
            }

            driver.FindElement(PageObjects.closeButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchGender).SendKeys("Select");
            driver.FindElement(PageObjects.PatientSearchZIP).Clear();
            driver.FindElement(PageObjects.PatientSearchMRN).Clear();

            //Test is passed or failed
            if (option1 == true && option2 == true && option3 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2SearchEntry", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchValidateConfiguration2SearchEntry", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }


        }

        [Test]
        public void TestGlobalSearchPatientSummary()
        {
            bool option1 = false; //sets to true if all tabs are displayed for eg, demographics, visits, clinical summary etc
            bool option2 = false; //sets to true if clinical summary tab has some records
            bool option3 = false; //sets to true if visits tab has some records
            bool option4 = false; //sets to true if documents tab has some records

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchPatientSummary");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(By.PartialLinkText("BOOK , RITAS")).Click();
            Thread.Sleep(6000);

            //To check if all the tabs are available or not
            if(driver.FindElement(PageObjects.demographicsection).Displayed)
            {
                if (driver.FindElement(PageObjects.PatientSearchVisitsTab).Displayed)
                {
                    if (driver.FindElement(PageObjects.PatientSearchDocumentTab).Displayed)
                    {
                        if (driver.FindElement(PageObjects.PatientSearchSecureMessageTab).Displayed)
                        {
                            if (driver.FindElement(PageObjects.patientsummaryClinicalSummarytab).Displayed)
                            {
                                if (driver.FindElement(PageObjects.patientsummaryflowsheetstab).Displayed)
                                {
                                    if (driver.FindElement(PageObjects.patientsummaryConsultsOrderstab).Displayed)
                                    {
                                        if (driver.FindElement(PageObjects.patientsummaryHospitalDowntimetab).Displayed)
                                        {
                                            option1 = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Thread.Sleep(6000);

            //To check if there is any clinical summary 
            driver.FindElement(PageObjects.patientsummaryClinicalSummarytab).Click();
            Thread.Sleep(6000);
            if (driver.FindElement(PageObjects.patientsummaryclinicalmedications).Displayed)
            {
                if (driver.FindElement(PageObjects.patientsummaryclinicalallergies).Displayed)
                {
                    if (driver.FindElement(PageObjects.patientsummaryclinicalproblems).Displayed)
                    {
                        if (driver.FindElement(PageObjects.patientsummaryclinicalimmunizations).Displayed)
                        {
                            option2 = true;
                        }
                    }
                }
            }
            Thread.Sleep(6000);
     
            //To check if there are any visits
            driver.FindElement(PageObjects.PatientSearchVisitsTab).Click();
            Thread.Sleep(6000);
            if (driver.FindElements(PageObjects.patientsummaryvisitrecordtable).Count > 0)
            {
                option3 = true;
            }
            Thread.Sleep(6000);
            
            //To check if there are any documents
            driver.FindElement(PageObjects.PatientSearchDocumentTab).Click();
            Thread.Sleep(6000);
            if (driver.FindElement(PageObjects.patientsummarydocrecords).Displayed)
            {
                option4 = true;
            }
            Thread.Sleep(6000);

            //Close patient summary page
            driver.FindElement(PageObjects.closepatientsummary).Click();
            Thread.Sleep(6000);

            //Test is passed or failed
            if (option1 == true && option2==true && option3==true && option4==true)
             {
                 Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientSummary", "Pass");
                 logoff();
                 Thread.Sleep(2000);
                 Assert.Pass();
             }
             else
             {
                 Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientSummary", "Fail");
                 logoff();
                 Thread.Sleep(2000);
                 Assert.Fail();
             }
             

        }

        [Test]
        public void TestGlobalSearchPatientDocsView()
        {
            bool option1 = false; //set to true if a documents is viewable or printable

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchPatientDocsView");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);
            
            driver.FindElement(PageObjects.PatientSearchActionDocuments).Click();
            Thread.Sleep(8000);

            //select any document and open it
            driver.FindElement(PageObjects.patientsummaryselectdoc).Click();
            Thread.Sleep(6000);

            //check if the pdf is printable 
           if(IsWebElementPresent(driver, PageObjects.patientsummarydocpdfprint))
            {
                option1 = true;
            }

           //close the pdf document
            driver.FindElement(PageObjects.patientsummarydocpdfclose).Click();
            Thread.Sleep(6000);

            //Close patient summary page
            driver.FindElement(PageObjects.closepatientsummary).Click();
            Thread.Sleep(6000);
            
            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientDocsView", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientDocsView", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }

        }

        [Test]
        public void TestGlobalSearchPatientFacesheetView()
        {
            bool option1 = false; //set to true if a patient's facesheet is viewable or printable

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchPatientFacesheetView");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionPatientSummary).Click();
            Thread.Sleep(8000);

            //Go to Visits tab
            driver.FindElement(PageObjects.PatientSearchVisitsTab).Click();
            Thread.Sleep(2000);
            driver.FindElement(PageObjects.PatientSearchFaceSheetViewButton).Click();
            Thread.Sleep(6000);

            //If the facesheet is printable
            if (IsWebElementPresent(driver, PageObjects.patientsummarydocpdfprint))
            {
                option1 = true;
            }

            //close the facesheet document
            driver.FindElement(PageObjects.PatientSearchFaceSheetCloseButton).Click();
            Thread.Sleep(6000);

            //Close patient summary page
            driver.FindElement(PageObjects.closepatientsummary).Click();
            Thread.Sleep(6000);

            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientFacesheetView", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchPatientFacesheetView", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void TestGlobalSearchCreateOrders()
        {
            bool option1 = false; //set to true if order can be created

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchCreateOrders");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionCreateOrder).Click();
            Thread.Sleep(6000);

            //check if physician and location can be selected to create orders

            if (IsWebElementPresent(driver, PageObjects.PatientSearchCreateConsultOrderSelectPhysician))
            {
                if (IsWebElementPresent(driver, PageObjects.PatientSearchCreateConsultOrderSelectLocation))
                {
                    option1 = true;
                }
            }

                //Test is passed or failed
                if (option1 == true)
                {
                    Excelinput.fnUpdateResultinExcel("TestGlobalSearchCreateOrders", "Pass");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Pass();
                }
                else
                {
                    Excelinput.fnUpdateResultinExcel("TestGlobalSearchCreateOrders", "Fail");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Fail();
                }

            }

        [Test]
        public void TestGlobalSearchNewMessage()
        {
            bool option1 = false; //set to true if a new message can be created

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchNewMessage");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionNewMessage).Click();
            Thread.Sleep(6000);

            //check if new secure message screen opens up

            if (IsWebElementPresent(driver,PageObjects.PatientSearchNewSecureMessageScreen))
            {
                option1 = true;
            }

            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchNewMessage", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchNewMessage", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }
        }

        [Test]
        public void TestGlobalSearchCreatePatient()
        {
            bool option1 = false; //set to true if you are able to create a new patient

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchCreatePatient");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchCreatePatientButton).Click();
            Thread.Sleep(6000);

            //check if create new patient screen is opened
            if(IsWebElementPresent(driver,PageObjects.PatientSearchCreatePatientScreen))
            {
                option1 = true;
            }

            //close the create new patient screen
            driver.FindElement(PageObjects.PatientSearchCreatePatientCancelButton).Click();
            Thread.Sleep(6000);

            //Test is passed or failed
            if (option1 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchCreatePatient", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchCreatePatient", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }

        }

        [Test]
        public void TestGlobalSearchManualPatientValidate()
        {
            bool option1 = false; //set to true if you are able to view a manually created patient

            goToHomePage();
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchManualPatientValidate");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set C-Global Search Required Parameters Option = 1
            SetConfigurationCglobal("1");

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //Test if the action button is displayed 

                if (IsWebElementPresent(driver, PageObjects.PatientSearchActionButton))
                {
                    option1 = true;
                }

            //Test is passed or failed
            if (option1 == true)
                {
                    Excelinput.fnUpdateResultinExcel("TestGlobalSearchManualPatientValidate", "Pass");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Pass();
                }
                else
                {
                    Excelinput.fnUpdateResultinExcel("TestGlobalSearchManualPatientValidate", "Fail");
                    logoff();
                    Thread.Sleep(2000);
                    Assert.Fail();
                }
        }

        [Test]
        public void TestGlobalConsentRelatedSearch()
        {
            bool option1 = false; //set to true if you are not able to view a minor patient's documents
            bool option2 = false; //set to true if you are not able to view a community patient's documents
            bool option3 = false; //set to true if you are not able to view a soft deleted patient

            //Testing this test case in version 512

            SetUp();
            driver.Navigate().GoToUrl("https://cernprpwebdev01.northamerica.cerner.net/EA512Test/clinical#/");
            Thread.Sleep(1000);

            //Login
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalConsentRelatedSearch");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set Consent Related System Settings in ISI System Administrator role
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
            Thread.Sleep(1000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
            driver.FindElement(PageObjects.changeRole).Click();
            Thread.Sleep(2000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as ISI System Administrator
            Thread.Sleep(4000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
            driver.FindElement(PageObjects.homepageMaintenance).Click();
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
            driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Patient Consent Default with no consent on file: (Permit, Deny, None)");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("Permit");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).Clear();
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Patient Consent Maximum Age for Minor");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("13");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).Clear();
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Patient Consent Minimum Age for Minor");
            driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
            driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).Clear();
            driver.FindElement(By.XPath("//textarea[@ng-model='viewModel.body']")).SendKeys("6");

            driver.FindElement(By.XPath("//button[contains(text(), 'Save')]")).Click();

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //Minor Patient Search
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);

            //Validate if the documents for minor are visible or not; if it's not set the boolean variable to true
            if(!IsWebElementPresent(driver, PageObjects.PatientSearchActionDocuments))
            {
                option1 = true;
            }

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();

            //Input the Community Record Patient's data
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(12).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(14).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(16).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //Validate if there is any patient returned; if it's not set the boolean variable to true 
            if (!IsWebElementPresent(driver, PageObjects.PatientSearchActionButton))
            {
                option2 = true;
            }

            driver.FindElement(PageObjects.PatientSearchPatientLastName).Clear();
            driver.FindElement(PageObjects.PatientSearchDOB).Clear();
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).Clear();

            //Input the Patient's data who has been soft deleted
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(18).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(20).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(22).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            //Validate if the documents for this patient are visible or not; if it's not set the boolean variable to true 
            if (!IsWebElementPresent(driver, PageObjects.PatientSearchActionButton))
            {
                option3 = true;
            }

            //Test is passed or failed
            if (option1 == true && option2==true && option3==true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalConsentRelatedSearch", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalConsentRelatedSearch", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }

        }

        [Test]
        public void TestGlobalSearchConsentDeniedPatient()
        {
            bool option1 = false; //set to true if patient has denied consent and no docuents are seen
            bool option2 = false;

            //Testing this test case in version 512
            SetUp();
            driver.Navigate().GoToUrl("https://cernprpwebdev01.northamerica.cerner.net/EA512Test/clinical#/");
            Thread.Sleep(1000);

            //Login
            Array arrInput = Excelinput.fnGetTestInputValues("TestGlobalSearchConsentDeniedPatient");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.loginUserNameInput));

            driver.FindElement(PageObjects.loginUserNameInput).SendKeys(arrInput.GetValue(2).ToString());
            driver.FindElement(PageObjects.loginPasswordInput).SendKeys(arrInput.GetValue(4).ToString());
            driver.FindElement(PageObjects.loginLoginButton).Click();
            Thread.Sleep(6000);

            //Set the role to Demo Practice Administrator to perform Global Search
            SetRoleDemoPracticeAdmin();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchSearchMenu));
            Thread.Sleep(4000);
            driver.FindElement(PageObjects.PatientSearchSearchMenu).Click();//to click on search
            Thread.Sleep(4000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientSearchPatientDropdown));
            driver.FindElement(PageObjects.PatientSearchPatientDropdown).Click();//patient search
            Thread.Sleep(2000);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.PatientGlobalSearchButton));
            Thread.Sleep(3000);
            driver.FindElement(PageObjects.PatientGlobalSearchButton).Click();
            Thread.Sleep(2000);

            //Search for the patient whose content is denied
            driver.FindElement(PageObjects.PatientSearchPatientLastName).SendKeys(arrInput.GetValue(6).ToString());
            driver.FindElement(PageObjects.PatientSearchDOB).SendKeys(arrInput.GetValue(8).ToString());
            driver.FindElement(PageObjects.PatientSearchPatientFirstName).SendKeys(arrInput.GetValue(10).ToString());
            driver.FindElement(PageObjects.PatientSearchSearchButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.otheroption).Click();
            driver.FindElement(PageObjects.comments).SendKeys("Testing");
            driver.FindElement(PageObjects.okButton).Click();
            Thread.Sleep(6000);

            driver.FindElement(PageObjects.PatientSearchActionButton).Click();
            Thread.Sleep(6000);

            //Validate if the documents for patient is visible or not; it should not be since the consent is denied
            if (!IsWebElementPresent(driver, PageObjects.PatientSearchActionDocuments))
            {
                option1 = true;
            }

            if(option1 == true)
            {
                //Set Consent Related System Settings in ISI System Administrator role
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(PageObjects.changeRole));
                Thread.Sleep(1000);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.changeRole));
                driver.FindElement(PageObjects.changeRole).Click();
                Thread.Sleep(2000);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.ISISystemAdministratorSelectRole));
                Thread.Sleep(4000);
                driver.FindElement(PageObjects.ISISystemAdministratorSelectRole).Click();// To select the role as ISI System Administrator
                Thread.Sleep(4000);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(PageObjects.homepageMaintenance));
                driver.FindElement(PageObjects.homepageMaintenance).Click();
                Thread.Sleep(2000);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-menu-id='sysset']")));
                driver.FindElement(By.XPath("//a[@data-menu-id='sysset']")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys("C-Patient Consent Default with no consent on file: (Permit, Deny, None)");
                driver.FindElement(By.XPath("//input[@class='k-input' and @aria-label='Setting Name']")).SendKeys(Keys.Enter);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Edit')]")));
                driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]")).Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@ng-model='viewModel.body']")));

               //Check if the configuration is set to deny
                if (IsWebElementPresent(driver, By.XPath("//*[contains(text(), '        Deny    ')]")))
                {
                    option2 = true;
                }
                driver.FindElement(By.XPath("//button[contains(text(), 'Cancel')]")).Click();
            }

            //Test is passed or failed
            if (option1 == true && option2 == true)
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchConsentDeniedPatient", "Pass");
                logoff();
                Thread.Sleep(2000);
                Assert.Pass();
            }
            else
            {
                Excelinput.fnUpdateResultinExcel("TestGlobalSearchConsentDeniedPatient", "Fail");
                logoff();
                Thread.Sleep(2000);
                Assert.Fail();
            }



        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

       public bool IsWebElementEnabled(IWebDriver webdriver, By webelement)
        {
            try
            {
                if (webdriver.FindElement(webelement).Enabled)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }


        public bool IsWebElementPresent(IWebDriver webdriver, By webelement)
        {
            try
            {
                if (webdriver.FindElement(webelement).Displayed)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
