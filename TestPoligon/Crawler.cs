using System;
using System.Collections.Generic;
using System.Net;


namespace WebCrawler
{

    class Link
    {
        public readonly string linkStr;
        private List<Link> _childLinks { get; set; }
        public bool _isValid;

        public Link(string linkStr)
        {
            this.linkStr = linkStr;
            _childLinks = new List<Link>();
            _isValid = true;
     
        }

        public List<Link> GetChildLinks()
        {
                LinkFinder linkFinder = new LinkFinder(linkStr);

                try
                {
                    List<string> temp = linkFinder.GetSiteLinks();
                    foreach (var element in temp)
                    {
                        _childLinks.Add((Link)element);
                    }
                }
                catch
                {
                    _isValid = false;
                }


                return _childLinks;
        }

        public static explicit operator Link(string v)
        {  
            Link ln = new Link(v);
            return ln;
        }
    }

    

    class Crawler
    {
        List<Link> _rootPageLinks = new List<Link>();

        public int SearchDepth { get; set; } = 0;

        public Crawler(string uri)
        {
            var finder = new LinkFinder(uri);
        }


       
    }

}
