using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RssModel;
using RssModel.Interfaces;
using RssModel.Model;

namespace TestRssReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<IChannel> ChannelCollection { get; set; }
        public ObservableCollection<IPost> PostsCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
            ChannelCollection = new ObservableCollection<IChannel>();
            PostsCollection = new ObservableCollection<IPost>();
            var rssReader = new RssReader(@"C:\Users\trott\Downloads\subscriptions.xml");
            var channels = rssReader.GetSubscriptionChannels();
            ChannelTitles.DataContext = channels;

            foreach (var channel in channels)
            {
                foreach (var post in channel.Posts)
                {
                    PostsCollection.Add(post);
                }
            }
        }
    }
}
