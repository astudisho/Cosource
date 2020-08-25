using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace Cosource.Scrap
{
    public class Scrap
    {
        private static ScrapingBrowser _browser;

        public Scrap()
        {
            if (_browser is null) _browser = new ScrapingBrowser();
        }

        public async Task<HtmlNode> GetHtml(string url)
        {
            var webPageTask = await _browser.NavigateToPageAsync(new Uri(url));
            
            return webPageTask.Html;
        }


    }
}