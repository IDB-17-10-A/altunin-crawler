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
        private WebClient _webClient = new WebClient();
        private string _patternDefault = "(?<=href=\").*?(?=\")";


        public List<String> GetAllLinkInPage(string url)
        {
            string tempPage;
            List<String> links = new List<string>();

            _webClient.Encoding = Encoding.UTF8;
            tempPage = _webClient.DownloadString(url);

            MatchCollection matchCollection = Regex.Matches(tempPage, _patternDefault);

            foreach (var element in matchCollection)
            {
                var temp = element.ToString();

                if (temp.StartsWith("/"))
                {
                    // replace first '/' with an empty char
                    temp = url + temp;
                }

                if (!(temp == "/") && !string.IsNullOrEmpty(temp) && !(temp == "#")
                    && !temp.Contains(".pdf") && !temp.Contains(".doc") && !temp.Contains(".docx"))
                    links.Add(temp);
            }

            return links;
        }

    }
}
