using HtmlAgilityPack;
using System;
using System.Threading.Tasks;
using Xunit;

using Cosource.Scrap;
using Cosource.Models.Jnet;

namespace Cosource.Parser.Jnet.Tests
{
    public class ProductTests
    {
        private Scrap.Scrap _scrap;
        private Parser _parser;

        public ProductTests()
        {
            _scrap = new Scrap.Scrap();
            _parser = new Parser();
        }

        [Theory]
        [InlineData("https://www.justforswimming.com/Listing_i39596")]
        public async Task Should_Parse_Product_Object_Correctly(string url)
        {
            // Arrange.
            var result = await GetItemProps(url);

            // Act.
            var parseObject = _parser.ParseProduct(result);

            // Assert.
            Assert.NotNull(parseObject);
            Assert.IsType<Product>(parseObject);            
        }


        private async Task<HtmlNodeCollection> GetItemProps(string url)
        {
            const string itemPropsXpath = "//*[@itemprop]";
            var node = await _scrap.GetHtml(url);
            var result = await _scrap.GetNodesByXpath(node, itemPropsXpath);
            return result;
        }
    }
}