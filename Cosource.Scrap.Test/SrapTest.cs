using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cosource.Scrap.Test
{    
    public class SrapTest
    {
        private Scrap _scrap;
        public SrapTest()
        {
            _scrap = new Scrap();
        }
        [Theory]
        [InlineData("https://au.justforshoesonline.com/Listing_i2379")]
        public async Task Should_Return_Valid_Html(string urlString)
        {
            var result = await GetHtml(urlString);
        }
        [Theory]
        [InlineData("https://au.justforautoparts.com/Listing_i19656")]
        public async Task Should_Return_Page_Not_Found(string urlString)
        {
            var result = await GetHtml(urlString);
        }
        [Theory]
        [InlineData("https://au.justforshoesonline.com/Listing_i2379")]
        public async Task Should_Get_Item_Prop_Nodes(string url)
        {
            const string itemPropsXpath = "//*[@itemprop]";
            var node = await GetHtml(url);
            var result = await _scrap.GetNodesByXpath(node, itemPropsXpath);
        }

        [Theory]
        //[InlineData("https://au.justforshoesonline.com/Listing_i2379")]
        [InlineData("https://www.justforswimming.com/Listing_i39596")]
        public async Task Should_Get_Item_Price_Node(string url)
        {
            // Arrange.
            const string itemPropsXpath = "//*[@itemprop]";
            var node = await GetHtml(url);
            var result = await _scrap.GetNodesByXpath(node, itemPropsXpath);

            // Act.
            var priceItem = result.FirstOrDefault(x => x.Attributes.Any(y => y.Value.Equals("price", StringComparison.InvariantCultureIgnoreCase)));

            // Assert.
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Theory]
        [InlineData("https://juliusmarlow.com.au/shoes/slip-on-shoes/haul-brown?utm_source=&utm_medium=CommissionFactory&utm_content=Data+Feed+Link&utm_campaign=Julius+Marlow&cfclick=0f593b491a234d429f134b539f90c2c5")]
        public async Task Should_Get_Supplier_Web_Page(string url)
        {
            var xpath = "[class=price]";
            var node = await GetHtml(url);
            var result = _scrap.GetNodesByCss(node, xpath);

        }

        private async Task<HtmlNode> GetHtml(string urlString)
        {
            var result = await _scrap.GetHtml(urlString);
            return result;
        }
    }
}
