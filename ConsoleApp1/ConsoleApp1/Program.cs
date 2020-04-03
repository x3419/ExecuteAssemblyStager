//using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Program
    {

        

        static void Main(string[] args)
        {

            //Assembly DLL = Assembly.Load(File.ReadAllBytes(@"C:\Users\User\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\WebDriver.dll"));
            // Assembly DLL_working = Assembly.LoadFile(@"C:\Users\User\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\WebDriver.dll");

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            byte[] response = new System.Net.WebClient().DownloadData(@"https://github.com/x3419/ExecuteAssemblyStager/raw/master/bin/WebDriver.dll");
            var DLL = Assembly.Load(response);


            Type calcType = DLL.GetType("OpenQA.Selenium.Chrome.ChromeDriver");
            Type calcType2 = DLL.GetType("OpenQA.Selenium.Remote.RemoteNavigator");

                                                                       // INSERT chromedriver.exe PATH HERE
            object calcInstance = Activator.CreateInstance(calcType, @"C:\Users\User\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug");

            String url = "http://www.google.com";
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments(new List<string>() { "headless" });
            
            var test = calcType.InvokeMember("Navigate", BindingFlags.InvokeMethod, null, calcInstance, null);
            var test2 = calcType2.InvokeMember("GoToUrl", BindingFlags.InvokeMethod, null, test, new object[] { url });

        }
    }
}
