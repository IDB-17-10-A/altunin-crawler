using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawler
{
    class LinkFinder
    {
        private WebClient _webClient;

        private const string PatternDefault = "(?<=href=\").*?(?=\")";
        private const string PatternForDomen = @"(?<=(http||https):\/\/).*";

        private readonly string _defaultUrl, _defaultDomen;

        private List<string> _siteLinks, _otherLinks;

        public LinkFinder(string defaultUrl)
        {
            _defaultUrl = defaultUrl;
            _webClient = new WebClient();
            _defaultDomen = Regex.Match(defaultUrl, PatternForDomen).ToString();
        }

        /// <summary>
        /// Get all links on page with default url
        /// </summary>
        /// <returns>list with all links on page</returns>
        private List<String> GetAllLinksOnPage()
        {
            string tempPage;
            List<String> links = new List<string>();

            _webClient.Encoding = Encoding.UTF8;
            tempPage = _webClient.DownloadString(_defaultUrl);

            MatchCollection matchCollection = Regex.Matches(tempPage, PatternDefault);

            foreach (var element in matchCollection)
            {
                //System.Threading.Thread.Sleep(3000);
                var temp = element.ToString();

                if (!(temp == "/") && !string.IsNullOrEmpty(temp) && !(temp == "#")
                    && !temp.Contains(".pdf") && !temp.Contains(".doc") && !temp.Contains(".docx")
                    && !temp.StartsWith("#"))
                {
                    if (temp.StartsWith("//"))
                    {
                        temp = temp.Remove(0, 1);
                        temp = _defaultUrl + temp;
                    }
                    else if(temp.StartsWith("/"))
                    {
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

        public List<string> GetSiteLinks()
        {
            if (_siteLinks == null)
            {
                SortLinks(GetAllLinksOnPage());
            }
            return _siteLinks;

        }

        public List<string> GetOtherLinks()
        {
            if (_otherLinks == null)
            {
                SortLinks(GetAllLinksOnPage());
            }
            return _otherLinks;
        }
    }
}
