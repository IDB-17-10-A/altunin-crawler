using System.Net;
using System.Threading.Tasks;
using System;
using System.Text;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            //LinkFinder linkFinder = new LinkFinder(@"http://stankin.ru");
            //foreach(var element in linkFinder.GetSiteLinks())
            //{
            //    Console.WriteLine(element);
            //}
            Crawler crawler = new Crawler("http://stankin.ru");
            Console.ReadKey();
        }
    }


   
}
