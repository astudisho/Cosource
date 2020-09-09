using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<HtmlNodeCollection> GetNodesByXpath(HtmlNode html, string xpath)
        {
            var result = html.SelectNodes(xpath);
            return result;
        }

        public IList<HtmlNode> GetNodesByCss(HtmlNode html, string cssSelector)
        {
            var result = html.CssSelect(cssSelector).ToList();
            return result;
        }

    }
}