using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;

namespace WebCrawler
{
    class Link
    {
        Link _childLink;

        List<string> resultingLinks;

        public Link() // int searchdepth
        {
            // some link gathering code in here

            // if search depth > 0
            // _childLink = new Link(searchDepth);
        }
    }

    class Crawler
    {
        private WebClient _webClient;

        private const string PATTERN_DEFAULT = "(?<=href=\").*?(?=\")",
        PATTERN_FOR_DOMEN = @"(?<=(http||https):\/\/).*";
     
        private readonly string _defaultUrl,_defaultDomen;
        private List<string> _siteLinks,_otherLinks;

         
        public Crawler(string defaultUrl)
        {
            _defaultUrl = defaultUrl;
            _webClient = new WebClient();
            _defaultDomen = Regex.Match(defaultUrl,PATTERN_FOR_DOMEN).ToString();
        }

        /// <summary>
        /// Get all links on page with default url
        /// </summary>
        /// <returns>list with all links on page</returns>
        public List<String> GetAllLinkOnPage()
        {
            string tempPage;
            List<String> links = new List<string>();

            _webClient.Encoding = Encoding.UTF8;
            tempPage = _webClient.DownloadString(_defaultUrl);

            MatchCollection matchCollection = Regex.Matches(tempPage, PATTERN_DEFAULT);

            foreach (var element in matchCollection)
            {
                var temp = element.ToString();

                if (!(temp == "/") && !string.IsNullOrEmpty(temp) && !(temp == "#")
                    && !temp.Contains(".pdf") && !temp.Contains(".doc") && !temp.Contains(".docx") 
                    && !temp.StartsWith("#"))
                {
                    if (temp.StartsWith("/"))
                    {
                        // replace first '/' with an empty char
                        temp = _defaultUrl + temp;
                    }
                    links.Add(temp);

                }

            }

            return links;
        }

        /// <summary>
        /// Distribution of links related to the site and not related
        /// </summary>
        private void SortLinks(List<string> allLinks)
        {
            _siteLinks = new List<string>();
            _otherLinks = new List<string>();
            foreach (var element in allLinks)
            {

                if (element.Contains(_defaultDomen))
                {
                    _siteLinks.Add(element);
                }
                else
                {
                    _otherLinks.Add(element);
                }
            }
        }


        public void Craw()
        {
            SortLinks(GetAllLinkOnPage());

            // for debug
            Console.WriteLine("Site links: ");
            foreach (var element in _siteLinks)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nOther links: ");
            {
                foreach (var element in _otherLinks)
                {
                    Console.WriteLine(element);
                }
            }

        }
    }
}
