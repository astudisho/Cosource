using System.ComponentModel;

namespace Cosource.Models.Jnet
{
    public class Product
    {
        public bool IsInStock { get; set; }
        public bool IsProductNameFound { get; set; }
        public string ProductName { get; set; }        
        public Price Price { get; set; }


        public static string ItemPropertyNamePrice => "price";
        public static string ItemPropertyNameProduct => "name";
        public static string ItemPropertyNameStock => "availability";
    }
}