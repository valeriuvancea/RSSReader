using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RssReader.Helpers;

namespace RssReader.Models
{
    [XmlRoot(ElementName = "rss")]
    public class RSSChannelModel
    {
        [XmlArray("channel")]
        [XmlArrayItem("item")]
        public NewsModel[] NewsArray { get; set; }
        public HTTPWorkerError httpWorkerError { get; set; } = HTTPWorkerError.NoError;
    }
}
