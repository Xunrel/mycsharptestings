using System;
using System.Collections.Generic;

namespace RssModel.Model
{
    public class Channel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string XmlUrl { get; set; }
        public string HtmlUrl { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
