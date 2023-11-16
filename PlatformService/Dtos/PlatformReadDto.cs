using PlatformService.Core.Models;

namespace PlatformService.Dtos
{
    public class PlatformReadDto: BaseEntity
    { 
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
