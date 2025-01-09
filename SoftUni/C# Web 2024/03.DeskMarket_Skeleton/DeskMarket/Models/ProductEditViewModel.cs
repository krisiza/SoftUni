using System.ComponentModel.DataAnnotations;
using static DeskMarket.Validations.ValidationConstants;
using static DeskMarket.Validations.ErrorMessages;

namespace DeskMarket.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength, ErrorMessage = NameLength)]
        public string ProductName { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string Description { get; set; }  = null!;

        [Range((double)PriceMinRange, (double)PriceMaxRange)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string AddedOn { get; set; } = null!;

        public int CategoryId { get; set; }

        public string SellerId { get; set; } = null!;

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
