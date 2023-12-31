﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<OrderItem>  OrderItems { get; set; } = new List<OrderItem>();
    }
}
