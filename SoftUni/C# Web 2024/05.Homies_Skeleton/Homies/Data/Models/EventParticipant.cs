using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Required]  
        public string HelperId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; } = null!;

        [Required]
        public int EventsId { get; set; }

        [Required]
        [ForeignKey(nameof(EventsId))]
        public Event Event { get; set; } = null!;
    }
}