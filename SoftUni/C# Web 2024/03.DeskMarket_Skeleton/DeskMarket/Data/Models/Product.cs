using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Validations.ValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        [Comment("Product Primary Key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Product Name")]
        public required string ProductName { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Product Description")]
        public required string Description { get; set; }

        [Required]
        [Range((double)PriceMinRange, (double)PriceMaxRange)]
        [Comment("Product Price")]
        public required decimal Price { get; set; }

        [Comment("Product ImageUrl")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Product SellerId")]
        public required string SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("Product AddedOn Date")]
        public required DateTime AddedOn { get; set; }

        [Required]
        [Comment("Product CategoryId")]
        public required int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Shows if product exists")]
        public bool IsDeleted { get; set; } = false;

        public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();

    }
}
