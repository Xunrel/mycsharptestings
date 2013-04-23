using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RssModel;

namespace RssModelTest
{
    [TestFixture]
    public class RssReaderTest
    {
        [Test]
        public void CanReadRss()
        {
            // arrange
            var reader = new RssReader(@"C:\Users\trott\Downloads\subscriptions.xml");

            // act
            var channels = reader.GetSubscriptionChannels();

            // assert
            Assert.IsNotNull(channels);
        }

        [Test]
        public void CannotReadWithoutSubscription()
        {
            // assert
            Assert.Throws<Exception>(() => new RssReader(""));
        }

        [Test]
        public void CannAddNewSubscription()
        {
            // arrange
            var reader = new RssReader(@"C:\Users\trott\Downloads\subscriptions.xml");
            var channels = reader.GetSubscriptionChannels();
            var lengthBefore = channels.Count();

            // act
            reader.AddChannel("http://heise.de.feedsportal.com/c/35207/f/653902/index.rss");

            // assert
            Assert.True(channels.Count() > lengthBefore);
            Assert.True(channels.Count() == lengthBefore + 1);
        }
    }
}
