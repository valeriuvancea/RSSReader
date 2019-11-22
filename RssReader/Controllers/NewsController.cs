using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RssReader.Helpers;
using RssReader.Models;

namespace RssReader.Controllers
{
    public class NewsController : Controller
    {
        private readonly IHTTPWorker _httpWorker;

        public NewsController(IHTTPWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        public IActionResult Index(string link = @"https://www.espn.com/espn/rss/news")
        {
            RSSChannelModel rssChanel = _httpWorker.GetRSSChanel(link);
            ViewData["Link"] = link;
            return View(rssChanel);
        }
    }
}