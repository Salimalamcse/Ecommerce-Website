using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Website.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }

        public string product_name { get; set; }

        public string product_Description { get; set; }

        public decimal product_Price { get; set; }

        public string product_image { get; set;}

        public int cat_id { get; set; }

        public Category Category { get; set; }

       
    }
}
