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
            
            Crawler crawler = new Crawler();

            foreach (var element in crawler.GetAllLinkInPage(@"http://stankin.ru"))
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }


   
}
