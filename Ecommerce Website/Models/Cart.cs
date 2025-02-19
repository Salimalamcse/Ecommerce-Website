using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Website.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int cart_id { get; set; }

        public int prod_id { get; set; }

        public int cust_id { get; set; }

        public int cus_id { get; set; }

        public int product_quntity { get; set; }

        public int cart_status { get; set; }

        [ForeignKey("prod_id")]
        public Product products { get; set; }

        [ForeignKey("cust_id")]
        public Customer customers { get;set; }

    }
}
