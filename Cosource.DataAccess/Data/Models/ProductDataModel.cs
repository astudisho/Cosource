using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cosource.DataAccess.Data.Models
{
    [Table("ProductCatalog")]
    internal class ProductDataModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Name { get; set; }
        [MaxLength(120)]
        public string Website { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsAvailable { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public Decimal Price { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public Decimal OldPrice { get; set; }
        public string Currency { get; set; }
    }
}
