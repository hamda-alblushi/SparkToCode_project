using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFcore_Project.Models
{
    public class Product
    {
        [Key]  
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }


        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category category { get; set; }


        public List<OrderProducts> orders { get; set; }
    }
}