using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFcore_Project.Models
{
    public class Review
    {
        [Key]
        public int reviewId { get; set; }
        public string reviewComment { get; set; }
        public string reviewDate { get; set; }


        [ForeignKey("order")]
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}