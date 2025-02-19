﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Website.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }

        public string category_name { get; set; }

        public  List<Product> Product { get; set; }
    }
}
