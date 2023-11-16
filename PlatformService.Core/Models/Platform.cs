using System.ComponentModel.DataAnnotations;

namespace PlatformService.Core.Models
{
    public class Platform : BaseEntity
    {
    
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}
