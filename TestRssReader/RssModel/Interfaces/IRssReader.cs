using System.Collections.Generic;
using RssModel.Model;

namespace RssModel.Interfaces
{
    public interface IRssReader
    {
        IList<Channel> Channels { get; set; }
        string SubscriptionPath { get; set; }
        Channel GetChannel(string url);
        IEnumerable<Channel> GetSubscriptionChannels();
        void AddChannel(string url);
    }
}