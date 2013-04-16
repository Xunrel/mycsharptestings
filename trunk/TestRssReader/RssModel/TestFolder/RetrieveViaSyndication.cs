using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssModel.TestFolder
{
    public class RetrieveViaSyndication
    {
        public IList<XElement> FeedPosts { get; set; }

        public void GetTitle(string url)
        {
            if (FeedPosts == null)
            {
                FeedPosts = new List<XElement>();
            }

            var posts = GetFeedData(url);
            foreach (var xElement in posts)
            {
                FeedPosts.Add(xElement);
            }
        }

        private IEnumerable<XElement> GetFeedData(string url)
        {
            var doc = XDocument.Load(url);

            var feed = from element in doc.Elements("rss").Elements("channel").Elements("item")
                       select element.Element("title");

            return feed;
        }
    }
}
