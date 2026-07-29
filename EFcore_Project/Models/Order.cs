using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFcore_Project.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public string orderDate { get; set; }


        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }


        [InverseProperty("order")]
        public Review review { get; set; }


        public List<OrderProducts> products { get; set; }
    }
}