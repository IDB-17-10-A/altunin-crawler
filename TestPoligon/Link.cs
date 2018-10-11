using System;
using System.Collections.Generic;
using System.Threading;

namespace WebCrawler
{
    class Link
    {
        public readonly string linkStr;
        public bool IsValid { get; private set; }

        public Link(string linkStr)
        {
            this.linkStr = linkStr;
            IsValid = true;
        }

        public List<Link> ChildLinks()
        {
            LinkFinder linkFinder = new LinkFinder(linkStr);
            List<Link> childLinks = new List<Link>();
            try
            {
                Thread.Sleep(2000);
                List<string> temp = linkFinder.GetSiteLinks();
                foreach (var element in temp)
                {
                    childLinks.Add((Link)element);
                    Console.WriteLine("current item received: " + element);
                }
            }
            catch
            {
                IsValid = false;
            }
            return childLinks;
        }

        public List<String> ChildLinksAsString()
        {
            List<String> resList = new List<string>();

            foreach (var element in ChildLinks())
            {
                resList.Add(element.linkStr);
            }

            return resList;
        }

        public static explicit operator Link(string v)
        {
            Link ln = new Link(v);
            return ln;
        }
    }

}
