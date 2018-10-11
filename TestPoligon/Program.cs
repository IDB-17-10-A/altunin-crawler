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
            
            //TO DO: 
            // 1) integrate more parse data
            // 2) integrate UI
            // 3) Fix some bugs
            // 4) Optimization

            Crawler crawler = new Crawler("http://stankin.ru",1);
            crawler.Parse();
            crawler.SaveInFile(@"D:\results.txt");
            Console.ReadKey();
        }
    }


   
}
