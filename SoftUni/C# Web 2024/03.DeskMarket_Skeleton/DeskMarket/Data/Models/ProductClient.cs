using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models
{
    [PrimaryKey(nameof(ProductId), nameof(ClientId))]
    public class ProductClient
    {
        [Comment("ProductClient First Primary Key - ProductId")]
        public required int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("ProductClient Second Primary Key - ClientId")]
        public required string ClientId { get; set; }

        public IdentityUser Client { get; set; } = null!;
    }
}