using System;
using NUnit.Framework;
using RssModel.Converter;

namespace RssModelTest
{
    [TestFixture]
    public class TestConverter
    {
        [Test]
        public void CanConvert()
        {
            // arrange
            var converter = new OpmlConverter(@"C:\Users\trott\Downloads\subscriptions.xml");

            // act
            var channelList = converter.Convert();

            // assert
            Assert.IsNotNull(converter);
            Assert.IsNotEmpty(channelList);
        }

        [Test]
        public void CanConvertToSyndicationFeeds()
        {
            // arrange
            var converter = new OpmlConverter(@"C:\Users\trott\Downloads\subscriptions.xml");

            // act
            var channelList = converter.ConvertSyndication();

            // assert
            Assert.IsNotNull(converter);
            Assert.IsNotEmpty(channelList);
        }
    }
}
