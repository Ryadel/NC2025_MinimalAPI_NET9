﻿namespace NC2025_MinimalAPI_NET8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign key
        public int CategoryId { get; set; }


        // Navigation property
        public Category Category { get; set; } = null!;
    }
}