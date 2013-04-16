using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RssModel.Converter;

namespace RssModelTest
{
    [TestFixture]
    public class SyndicationConverterTest
    {
        [Test]
        public void CanUseSubscriptionXml()
        {
            // arrange
            var path = @"C:\Users\Daniel\Documents\subscriptions.xml";
            var synd = new SyndicationConverter(path);

            // act
            synd.GetSubscriptionChannels();

            // assert
            Assert.IsNotEmpty(synd.Channels);
        }

        [Test]
        public void CannotUseSubscriptionPathIsNotSet()
        {
            // arrange
            var path = @"";
            var synd = new SyndicationConverter(path);

            // act
            synd.GetSubscriptionChannels();

            // assert
            Assert.IsEmpty(synd.FeedPosts);
        }
    }
}
