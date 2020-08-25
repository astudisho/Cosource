namespace Cosource.Models.Jnet
{
    public class Product
    {
        public bool IsInStock { get; set; }
        public bool IsProductNameFound { get; set; }
        public string ProductName { get; set; }
        public Price MyProperty { get; set; }
    }
}