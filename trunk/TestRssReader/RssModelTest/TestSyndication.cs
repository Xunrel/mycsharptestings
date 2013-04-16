using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RssModel.TestFolder;

namespace RssModelTest
{
    [TestFixture]
    public class TestSyndication
    {
        [Test]
        public void CanUseSyndication()
        {
            var synd = new RetrieveViaSyndication();
            synd.GetTitle("http://feeds.howtogeek.com/HowToGeek");

            Assert.IsNotNull(synd.FeedPosts);
        }
    }
}
