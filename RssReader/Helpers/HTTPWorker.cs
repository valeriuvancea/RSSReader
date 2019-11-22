using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RssReader.Models;

namespace RssReader.Helpers
{
    public enum HTTPWorkerError
    {
        NoError,
        EmptyHttpResponse,
        InvalidRSSXML
    }
    public class HTTPWorker : IHTTPWorker
    {
        public RSSChannelModel GetRSSChanel(string link)
        {
            if (String.IsNullOrEmpty(link))
            {
                return new RSSChannelModel { NewsArray = new NewsModel[0], httpWorkerError = HTTPWorkerError.EmptyHttpResponse };
            }
            string httpResponse = MakeHTTPGetRequest(link);

            if (String.IsNullOrEmpty(httpResponse))
            {
                return new RSSChannelModel { NewsArray = new NewsModel[0], httpWorkerError = HTTPWorkerError.EmptyHttpResponse };
            }

            return SerializeXML(httpResponse);
        }

        private string MakeHTTPGetRequest(string link)
        {
            string httpResponse = String.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                httpResponse = reader.ReadToEnd();
            }

            return httpResponse;
        }

        private RSSChannelModel SerializeXML(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RSSChannelModel));
            RSSChannelModel rssChannel = new RSSChannelModel();
            try
            {
                rssChannel = (RSSChannelModel)serializer.Deserialize(new StringReader(xml));
            }
            catch
            {
                rssChannel.NewsArray = new NewsModel[0];
                rssChannel.httpWorkerError = HTTPWorkerError.InvalidRSSXML;
            }
            return rssChannel;
        }
    }
}
