using System;

namespace RssModel.Interfaces
{
    public interface IPost
    {
        string PostGuid { get; set; }
        string Author { get; set; }
        DateTimeOffset? PubDate { get; set; }
        string Title { get; set; }
        string Link { get; set; }
        bool Read { get; set; }
    }
}