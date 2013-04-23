using System.Collections.Generic;
using System.Threading.Tasks;
using RssModel.Model;

namespace RssModel.Interfaces
{
    public interface IRssReader
    {
        IList<IChannel> Channels { get; set; }
        string SubscriptionPath { get; set; }
        IChannel GetChannel(string url);
        IEnumerable<IChannel> GetSubscriptionChannels();
        void AddChannel(string url);
    }
}