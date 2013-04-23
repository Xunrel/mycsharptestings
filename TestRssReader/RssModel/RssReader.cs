using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using RssModel.Interfaces;
using RssModel.Model;

namespace RssModel
{
    public class RssReader : IRssReader
    {
        #region Properties

        public IList<IChannel> Channels { get; set; }

        public string SubscriptionPath { get; set; }

        #endregion


        #region Constructor

        public RssReader(string subscriptionPath)
        {
            if (Channels == null)
            {
                Channels = new List<IChannel>();
            }
            if (!string.IsNullOrEmpty(subscriptionPath))
            {
                SubscriptionPath = subscriptionPath;
            }
            else
            {
                throw new Exception("SubscriptionPath should not be null or empty");
            }
        }

        #endregion


        private void ReadRssSubsriptions(string url)
        {
            var channel = GetChannel(url);

            if (channel != null)
            {
                Channels.Add(channel);
            }
        }

        public IChannel GetChannel(string url)
        {
            var doc = new XmlDocument();
            try
            {
                doc.Load(url);
            }
            catch (WebException wEx)
            {
                //                throw new WebException("Operation has timed out");
            }
            Channel channel = null;
            //Get Channel Node
            var channelNode = doc.SelectSingleNode("rss/channel");

            if (channelNode != null)
            {
                var descNode = channelNode.SelectSingleNode("description");
                var linkNode = channelNode.SelectSingleNode("link");
                var titleNode = channelNode.SelectSingleNode("title");

                channel = new Channel
                {
                    Description = descNode != null ? descNode.InnerText : "No description",
                    Link = linkNode != null ? linkNode.InnerText : "",
                    Title = titleNode != null ? titleNode.InnerText : "No title"
                };

                //Add NameSpace
                var nameSpace = new XmlNamespaceManager(doc.NameTable);
                nameSpace.AddNamespace("content", "http://purl.org/rss/1.0/modules/content/");
                nameSpace.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/");
                nameSpace.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

                //Parse each item
                var nodes = channelNode.SelectNodes("item");
                if (nodes != null)
                {
                    foreach (XmlNode itemNode in nodes)
                    {
                        //RssFeed rssItem = new RssFeed();
                        var guid = itemNode.SelectSingleNode("guid");
                        var title = itemNode.SelectSingleNode("title");
                        var author = itemNode.SelectSingleNode("dc:creator", nameSpace);
                        var altAuthor = itemNode.SelectSingleNode("author");
                        var link = itemNode.SelectSingleNode("link");
                        var pubDate = itemNode.SelectSingleNode("pubDate");
                        DateTimeOffset parsedDate;
                        if (pubDate != null)
                        {
                            DateTimeOffset.TryParse(pubDate.InnerText, out parsedDate);
                        }
                        else
                        {
                            parsedDate = DateTimeOffset.MinValue;
                        }
                        var post = new Post
                        {
                            PostGuid = guid != null ? guid.InnerText : "No guid",
                            Author = author != null ? author.InnerText : (altAuthor != null ? altAuthor.InnerText : "No author"),
                            Link = link != null ? link.InnerText : "",
                            PubDate = parsedDate,
                            Title = title != null ? title.InnerText : "No Title"
                        };
                        channel.Posts.Add(post);
                    }
                }
            }
            return channel;
        }

        public IEnumerable<IChannel> GetSubscriptionChannels()
        {
            if (!string.IsNullOrEmpty(SubscriptionPath))
            {
                using (var opmlReader = XmlReader.Create(SubscriptionPath))
                {
                    while (opmlReader.Read())
                    {
                        if (opmlReader.NodeType == XmlNodeType.Whitespace) continue;

                        var nodeType = opmlReader.NodeType;
                        var nodeName = opmlReader.Name;

                        if (nodeType == XmlNodeType.Element
                            && nodeName == "outline"
                            && opmlReader.IsEmptyElement)
                        {
                            var xmlUrl = opmlReader.GetAttribute("xmlUrl");
                            if (!string.IsNullOrEmpty(xmlUrl))
                            {
                                try
                                {
                                    ReadRssSubsriptions(xmlUrl);
                                }
                                catch (WebException wEx)
                                {
//                                    throw new WebException(string.Format("Operation has timed out for xmlUrl '{0}'", xmlUrl), wEx);
                                }
                                catch (Exception exception)
                                {
//                                    throw new Exception(string.Format("Could not read xml '{0}'", xmlUrl), exception);
                                }
                            }
                        }
                    }
                }
            }
            return Channels;
        }

        public void AddChannel(string url)
        {
            ReadRssSubsriptions(url);
        }
    }
}
