using MatchwiseServer.Domain.Entities.Common;
using MatchwiseServer.Domain.Entities.Identity;

namespace MatchwiseServer.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? CorporateName { get; set; }
        public string? TaxNumber { get; set; }
        public string? Sector { get; set; }
        public string? Location { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public ICollection<JobPosting>? JobPosting { get; set; }   // Bir şirketin birden fazla iş ilanı olabilir
    }
}
