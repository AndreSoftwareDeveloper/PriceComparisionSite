﻿using System.ComponentModel.DataAnnotations;

namespace PriceComparision.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Shop { get; set; }
    }
}
