using System;
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
            var result = await _scrap.GetHtml(urlString);
        }
        [Theory]
        [InlineData("https://au.justforautoparts.com/Listing_i19656")]
        public async Task Should_Return_Page_Not_Found(string urlString)
        {
            var result = await _scrap.GetHtml(urlString);
        }
    }
}
