using System.Collections.Generic;
using RssModel.Model;

namespace RssModel.Interfaces
{
    public interface IChannel
    {
        string Title { get; set; }
        string Link { get; set; }
        string Description { get; set; }
        IList<Post> Posts { get; set; }
    }
}