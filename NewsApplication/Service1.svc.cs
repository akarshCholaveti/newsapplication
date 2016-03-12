using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace NewsApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public String[] NewsFocus(String topics)
        {
            string requiredUrl = "href=(?:\"(?<URL>[^\"]*)\")";
            System.Net.WebClient webClient = new System.Net.WebClient();
            string[] url = new string[4];
            url[0] = "http://abcnews.go.com/search?searchtext=" + topics;
            url[1] = "http://www.foxnews.com/search-results/search?q=" + topics;
            url[2] = "http://www.cnn.com/search/?text=" + topics;
            url[3] = "http://www.bbc.co.uk/search?q=" + topics;
            string[] newsArticles = new string[20];
            string newsLink;
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                
                string newsUrl = url[i];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newsUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                String content = sr.ReadToEnd();
                sr.Close();
                content = webClient.DownloadString(newsUrl);
                Match m = Regex.Match(content, requiredUrl);
                int counter = 0;
                while (m.Success && counter < 5)
                {
                    newsLink = m.Groups["URL"].ToString();
                    if (newsLink.StartsWith("http") && !newsLink.Contains("css"))
                    {
                        newsArticles[count] = newsLink;
                        count++;
                        counter++;
                    }
                    m = m.NextMatch();
                }
            }
            string[] newsLinks = new string[20];
            for (int i = 0; i < 20; i++)
            {
                newsLinks[i] = ConvertUrlsToLinks(newsArticles[i]);
            }

            return newsArticles;
        }

        private string ConvertUrlsToLinks(string msg)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }
    }
}
