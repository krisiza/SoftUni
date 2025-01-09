using DeskMarket.Validations;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.CategoryNameMaxLength, MinimumLength = ValidationConstants.CategoryNameMinLength)]
        public required string Name { get; set; }
    }
}
