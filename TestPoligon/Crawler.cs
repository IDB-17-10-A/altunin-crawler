using System;
using System.Collections.Generic;
using System.IO;


namespace WebCrawler
{


    class Crawler
    {

        List<Link> _rootPageLinks;
        List<Link> _resultsLinks;
        public int SearchDepth { get; set; } = 0;

        public Crawler(string uri,int searchDepth)
        {
            _rootPageLinks = new List<Link>();
            _resultsLinks = new List<Link>();
            SearchDepth = searchDepth;
            Link rootLink = new Link(uri);
            foreach (var element in rootLink.ChildLinks())
            {
                _rootPageLinks.Add((Link)element);
            }
        }
        
        //rename this
        public void SaveInFile(string path)
        {
            using (StreamWriter srw = new StreamWriter(path))
            {

                foreach(var element in _resultsLinks)
                {
                    srw.WriteLine(element.linkStr);
                }
                Console.WriteLine("Finished");

              
            }
        }

        public void Parse()
        {
            List<List<Link>> list = new List<List<Link>>();
            List<Link> tempLink = _rootPageLinks;
            Console.WriteLine("Count _rootPage: " + tempLink.Count);
            for (int i = 0; i<SearchDepth;i++)
            {
                Console.WriteLine("Current depth: " + i);
                foreach (var element in tempLink)
                {
                    list.Add(element.ChildLinks());
                }
                Console.WriteLine(list.Count);
                tempLink = list[i];

            }

            foreach(var e1 in list)
            {
                foreach(var e2 in e1)
                {
                    _resultsLinks.Add(e2);
                }
            }
            Console.WriteLine("result links finished");

        }

    }

}
