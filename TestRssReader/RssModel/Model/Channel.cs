using System;
using System.Collections.Generic;
using RssModel.Interfaces;

namespace RssModel.Model
{
    public class Channel : IChannel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public IList<IPost> Posts { get; set; }

        public Channel()
        {
            if (Posts == null)
            {
                Posts = new List<IPost>();
            }
        }
    }
}
