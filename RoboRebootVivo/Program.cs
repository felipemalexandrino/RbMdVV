using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RoboRebootVivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string Login = "admin";
            string password = "78e1eb2d";

            //!Make sure to add the path to where you extracting the chromedriver.exe:
            IWebDriver driver = new ChromeDriver("\\bin\\Debug\\chormedriver"); //<-Add your path
            driver.Navigate().GoToUrl("http://192.168.17.1/cgi-bin/sophia_index.cgi");

            //Accesso ao menu lateral esquerdo - Gerenciamento > reiniciar
            driver.SwitchTo().Frame("menufrm");
            driver.FindElement(By.Id("devmenu"));
            driver.FindElement(By.Id("conteudo-gateway"));
            driver.FindElement(By.TagName("ul"));
            driver.FindElement(By.TagName("li"));
            driver.FindElement(By.TagName("li"));
            driver.FindElement(By.Id("devmenu")).Click();
            driver.FindElement(By.TagName("ul"));
            driver.FindElement(By.TagName("li"));
            driver.FindElement(By.TagName("li"));
            driver.FindElement(By.TagName("li"));
            driver.FindElement(By.Id("MLG_Menu_Resets")).Click();

            driver.SwitchTo().DefaultContent();

            //Acesso ao login
            driver.SwitchTo().Frame("basefrm");
            driver.FindElement(By.Id("conteudo-gateway"));
            driver.FindElement(By.TagName("div"));
            driver.FindElement(By.TagName("table"));
            driver.FindElement(By.TagName("tbody"));
            driver.FindElement(By.TagName("tr"));
            driver.FindElement(By.TagName("td"));
            driver.FindElement(By.TagName("td"));
            driver.FindElement(By.TagName("input")).SendKeys(Login);
            driver.FindElement(By.TagName("tr"));
            driver.FindElement(By.TagName("tr"));
            driver.FindElement(By.TagName("td"));
            driver.FindElement(By.Id("LoginPassword")).SendKeys(password);
            driver.FindElement(By.Id("acceptLogin")).Click();
            driver.SwitchTo().DefaultContent();

            //Reiniciar
            driver.SwitchTo().Frame("basefrm");
            driver.FindElement(By.TagName("form"));
            driver.FindElement(By.TagName("div"));
            driver.FindElement(By.TagName("table"));
            driver.FindElement(By.TagName("tbody"));
            driver.FindElement(By.TagName("tr"));
            driver.FindElement(By.TagName("td"));
            driver.FindElement(By.Id("btn-clicktocall")).Click();
            driver.SwitchTo().DefaultContent();

            //Acessar sub-Frame
            driver.SwitchTo().Frame("basefrm");
            driver.FindElement(By.TagName("div"));
            var elementos = driver.FindElements(By.TagName("iframe"));
            driver.SwitchTo().Frame(elementos.FirstOrDefault().GetAttribute("name"));

            var BotaoReboot = driver.FindElement(By.Id("MLG_Pop_Reboot_Yes"));
            //var BotaoRebootOF = driver.FindElement(By.Id("MLG_Pop_Reboot_No"));
            BotaoReboot.Click();
            driver.Close();
            //driver.FindElement(By.TagName("div"));
            //driver.FindElement(By.TagName("tbody"));
            //driver.FindElement(By.TagName("tr"));
            //driver.FindElement(By.LinkText("Yes, Reboot"));
        }

    }
}
