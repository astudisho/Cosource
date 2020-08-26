using Cosource.Models.Jnet;
using Cosource.Scrap;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace Cosource.Parser
{
    public class Parser
    {
        public Parser()
        {
        }
        public Product ParseProduct(HtmlNodeCollection htmlNodes)
        {

            var priceItem = htmlNodes.FirstOrDefault(x => x.Attributes.Any(y => y.Value.Equals(Product.ItemPropertyNamePrice, StringComparison.InvariantCultureIgnoreCase)));
            var nameItem = htmlNodes.FirstOrDefault(x => x.Attributes.Any(y => y.Value.Equals(Product.ItemPropertyNameProduct, StringComparison.InvariantCultureIgnoreCase)));
            var availabilityItem = htmlNodes.FirstOrDefault(x => x.Attributes.Any(y => y.Value.Equals(Product.ItemPropertyNameStock, StringComparison.InvariantCultureIgnoreCase)));

            var isNameItemAvailable = !(nameItem is null);
            var productName = nameItem?.InnerText;
            decimal.TryParse(priceItem.InnerText, out var productPrice);
            var availabilitySchema = availabilityItem.GetAttributeValue("content", null);
            var productAvailability = availabilitySchema?.Contains("InStock") ?? false;


            var result = new Product
            {
                IsProductNameFound = isNameItemAvailable,
                ProductName = productName,
                IsInStock = productAvailability,

            };
            return result;
        }
    }
}
