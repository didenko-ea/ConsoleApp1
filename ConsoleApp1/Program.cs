using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Appset
    {
        public Dictionary<string, string> sAllDict { get; set; }
    }
    public class StaticCache
    {
        private static Appset appset = null;

        public static Appset GetAppSetting()
        {
            Appset appset = new Appset();
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;
            appset.sAllDict = sAll.AllKeys.ToDictionary(t => t, t => sAll[t]);
            return appset;
        }
        public static void LoadStaticCache()
        {
            appset = StaticCache.GetAppSetting();
        }
        public static Appset GetAppset()
        {
            return appset;
        }
        public static void SetAppsetNull()
        {
            appset = null;
        }
    }

    class Program
    {
    static void Main(string[] args)
        {
            StaticCache.SetAppsetNull();
            StaticCache.LoadStaticCache();
            //var ddd = StaticCache.GetAppset().sAllDict.ToList().Where(s=>s.Key.Contains("грузовая"));

            Console.WriteLine(StaticCache.GetAppset().sAllDict.FirstOrDefault().Key + " " + StaticCache.GetAppset().sAllDict.FirstOrDefault().Value + "км");
            Console.WriteLine("Участники:");
            int i = 1;
                foreach (KeyValuePair<string,string> s in StaticCache.GetAppset().sAllDict.Skip(1).ToList())
                {
                    string stroka = s.Value.ToString();
                    string[] subs = stroka.Split(',');
                    int speed = Int32.Parse(subs[0]);
                    int prc = Int32.Parse(subs[1]);
                    int dop = Int32.Parse(subs[2]);
                    Console.WriteLine("номер №" + i.ToString() + " " + s.Key + ", ск: " + speed.ToString() + "км/ч , вер прокола: " + prc.ToString() + "% , доп: " + dop.ToString());
                    i++;
            }
            Console.ReadLine();
        }
    }
}
