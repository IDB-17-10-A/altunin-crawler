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
            Crawler crawler = new Crawler("http://stankin.ru",1);
            crawler.Parse();
            crawler.SaveInFile(@"D:\results.txt");
            Console.ReadKey();
        }
    }


   
}
