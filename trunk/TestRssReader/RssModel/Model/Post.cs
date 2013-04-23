using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssModel.Interfaces;

namespace RssModel.Model
{
    public class Post : IPost
    {
        public string PostGuid { get; set; }
        public string Author { get; set; }
        public DateTimeOffset? PubDate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public bool Read { get; set; }
    }
}
