using DeskMarket.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("Category Primary Key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        [Comment("Category Name")]
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}