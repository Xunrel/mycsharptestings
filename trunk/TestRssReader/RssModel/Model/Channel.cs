using System;
using System.Collections.Generic;

namespace RssModel.Model
{
    public class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public IList<Post> Posts { get; set; }

        public Channel()
        {
            if (Posts == null)
            {
                Posts = new List<Post>();
            }
        }
    }
}
