using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RssModel.Model;

namespace RssModel.Converter
{
    public class OpmlConverter
    {
        private XmlReader _opmlReader;
        private readonly string _filePath = "";

        public OpmlConverter(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Channel> Convert()
        {
            var channels = new List<Channel>();
            using (_opmlReader = XmlReader.Create(_filePath))
            {
                while (_opmlReader.Read())
                {
                    if (_opmlReader.NodeType == XmlNodeType.Whitespace) continue;

                    var nodeType = _opmlReader.NodeType;
                    var nodeName= _opmlReader.Name;
                    var nodeLocalName = _opmlReader.LocalName;
                    if (nodeType == XmlNodeType.Element && nodeName == "outline" && _opmlReader.HasAttributes)
                    {
                        var channel = new Channel
                                          {
                                              HtmlUrl = _opmlReader.GetAttribute("htmlUrl"),
                                              XmlUrl = _opmlReader.GetAttribute("xmlUrl"),
                                              Type = _opmlReader.GetAttribute("type"),
                                              Title = _opmlReader.GetAttribute("title")
                                          };
                        if (!string.IsNullOrEmpty(channel.XmlUrl))
                        {
                            channel.Posts = ConvertPosts(channel.XmlUrl);
                        }
                        channels.Add(channel);
                    }
                }
            }

            return channels;
        }

        public IEnumerable<SyndicationFeed> ConvertSyndication()
        {
            var channels = new List<SyndicationFeed>();
            using (_opmlReader = XmlReader.Create(_filePath))
            {
                while (_opmlReader.Read())
                {
                    if (_opmlReader.NodeType == XmlNodeType.Whitespace) continue;

                    var nodeType = _opmlReader.NodeType;
                    var nodeName = _opmlReader.Name;
                    if (nodeType == XmlNodeType.Element && nodeName == "outline" && _opmlReader.HasAttributes)
                    {
                        Uri uriOut = null;
                        Uri.TryCreate(_opmlReader.GetAttribute("xmlUrl"), UriKind.Absolute, out uriOut);
                        channels.Add(new SyndicationFeed(_opmlReader.GetAttribute("title"),
                                                         _opmlReader.GetAttribute("title"),
                                                         uriOut));
                    }
                }
            }

            return channels;
        }

        private IEnumerable<Post> ConvertPosts(string url)
        {
            var posts = new List<Post>();

            var xmlReaderSettings = new XmlReaderSettings {Async = true};
            var counter = 0;
            using (var xmlReader = XmlReader.Create(url, xmlReaderSettings))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Whitespace) continue;

                    var nodeType = xmlReader.NodeType;
                    var nodeName = xmlReader.Name;

                    if (nodeType == XmlNodeType.Element && nodeName == "item" && counter < 3)
                    {
                        posts.Add(ConvertItemToPost(xmlReader.ReadInnerXml()));
                        counter++;
                    }
                }
            }

            return posts;
        }

        public Post ConvertItemToPost(string xmlContent)
        {
            var post = new Post();
            xmlContent = xmlContent.Replace("\n", "").Replace("\t", "").Replace("\r", "");
            using (var xmlReader = XmlReader.Create(xmlContent))
            {
                while (xmlReader.Read())
                {
                    var nodeType = xmlReader.NodeType;
                    var nodeName = xmlReader.Name;
                }
            }

            return post;
        }
    }
}
