using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RssReader.Models;

namespace RssReader.Helpers
{
    public interface IHTTPWorker
    {
        public RSSChannelModel GetRSSChanel(string link);
    }
}
