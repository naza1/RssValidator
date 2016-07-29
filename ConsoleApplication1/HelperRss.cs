using System;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ConsoleApplication1

{
    public static class HelperRss
    {

        public static bool RssUrlIsValid(string rssUrl)
        {
            try
            {
                SyndicationFeed rss = GetRss(rssUrl);
                if (rss != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static SyndicationFeed GetRss(string rssUrl)
        {
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(rssUrl);
            http.Accept = "text/xml, */*";
            http.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us");
            http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
            http.KeepAlive = true;
            http.AutomaticDecompression = DecompressionMethods.Deflate |
                                         DecompressionMethods.GZip;
            var response = http.GetResponse();
            XmlReader reader = XmlReader.Create(response.GetResponseStream());

            return SyndicationFeed.Load(reader);
        }
    }
}
