using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFcore_Project.Models
{
    [PrimaryKey("orderId", "productId")]
    public class OrderProducts
    {
        [ForeignKey("orderProducts")]
        public int orderId { get; set; }


        [ForeignKey("productOrders")]
        public int productId { get; set; }


        public int quantity { get; set; }
    }
}