using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Models
{
    public class NewsModel
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
        [XmlElement("pubDate")]
        public string PublicationDate { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
    }
}
