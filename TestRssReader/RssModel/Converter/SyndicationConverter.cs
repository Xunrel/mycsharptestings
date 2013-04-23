using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using RssModel.Model;
using log4net;
using log4net.Config;

namespace RssModel.Converter
{
    public class SyndicationConverter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (SyndicationConverter));

        private XmlReader _opmlReader;

        public IList<XElement> FeedPosts { get; set; }
        public IList<XElement> FeedChannels { get; set; }

        public IList<Channel> Channels { get; set; }

        public string SubscriptionPath { get; set; }

        public SyndicationConverter()
        {
            XmlConfigurator.Configure();
            if (FeedPosts == null)
            {
                FeedPosts = new List<XElement>();
            }
            if (FeedChannels == null)
            {
                FeedChannels = new List<XElement>();
            }
            if (Channels == null)
            {
                Channels = new List<Channel>();
            }
        }

        public SyndicationConverter(string subscriptionPath)
        {
            if (FeedPosts == null)
            {
                FeedPosts = new List<XElement>();
            }
            if (FeedChannels == null)
            {
                FeedChannels = new List<XElement>();
            }
            if (Channels == null)
            {
                Channels = new List<Channel>();
            }
            SubscriptionPath = subscriptionPath;
        }

        public void GetSubscriptionChannels()
        {
            if (!string.IsNullOrEmpty(SubscriptionPath))
            {
                using (_opmlReader = XmlReader.Create(SubscriptionPath))
                {
                    while (_opmlReader.Read())
                    {
                        if (_opmlReader.NodeType == XmlNodeType.Whitespace) continue;

                        var nodeType = _opmlReader.NodeType;
                        var nodeName = _opmlReader.Name;
                        var nodeLocalName = _opmlReader.LocalName;

                        if (nodeType == XmlNodeType.Element
                            && nodeName == "outline"
                            && _opmlReader.IsEmptyElement)
                        {
                            var xmlUrl = _opmlReader.GetAttribute("xmlUrl");
                            if (!string.IsNullOrEmpty(xmlUrl))
                            {
                                try
                                {
                                    var channel = GetChannel(xmlUrl);
                                    Channels.Add(channel);
                                }
                                catch (Exception exception)
                                {
                                    Logger.Error("Could not get title");
                                }
                            }
                        }
                    }
                }
            }
        }

        private Channel GetChannel(string url)
        {
            var doc = XDocument.Load(url);

            var channel = (from element in doc.Elements("rss").Elements("channel")
                      select new Channel
                          {
                              Title = element.Element("title").Value,
                              Description = element.Element("description").Value,
                              Link = element.Element("link").Value
                          }).First();

            PopulateChannel(channel, doc);

            return channel;
        }

        private void PopulateChannel(Channel channel, XDocument doc)
        {
            var feeds = from element in doc.Elements("rss").Elements("channel").Elements("item")
                        select element;

            foreach (var feed in feeds)
            {
                DateTimeOffset pubDate;
                DateTimeOffset.TryParse(feed.Element("pubDate").Value, out pubDate);
//                var author = feed.Element("dc:creator") != null ? feed.Element("dc:creator").Value : "Unknown";
                var link = feed.Element("link") != null ? feed.Element("link").Value : "Unkown";
                var title = feed.Element("title") != null ? feed.Element("title").Value : "Unkown";
                var post = new Post
                    {
//                        Author = author,
                        Link = link,
                        Title = title,
                        PubDate = pubDate
                    };
                channel.Posts.Add(post);
            }
        }

        public void GetTitle(string url)
        {
            try
            {
                var posts = GetFeedData(url);
                foreach (var xElement in posts)
                {
                    FeedPosts.Add(xElement);
                }
            }
            catch (Exception exception)
            {
                Logger.Error("Could not get feed data");
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
