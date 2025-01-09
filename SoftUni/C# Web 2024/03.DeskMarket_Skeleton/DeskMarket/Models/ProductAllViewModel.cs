﻿namespace DeskMarket.Models
{
    public class ProductAllViewModel
    {

        public int Id { get; set; }

        public required string ProductName { get; set; }

        public required decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public required string SellerId { get; set; }

        public bool IsSeller { get; set; } = false;

        public bool HasBought { get; set; } = false;
    }
}