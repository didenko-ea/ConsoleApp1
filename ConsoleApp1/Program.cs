using System;
using System.Configuration;
using System.Collections.Specialized;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr; 
            sAttr = ConfigurationManager.AppSettings.Get("Key0");
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings; Console.WriteLine("Hello World!");
            foreach (string s in sAll.AllKeys)
                Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
            Console.ReadLine();
        }
    }
}
