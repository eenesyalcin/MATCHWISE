using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? CorporateName { get; set; }
        public string? TaxNumber { get; set; }
        public string? Sector { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        public ICollection<JobPosting>? JobPosting { get; set; }   // Bir şirketin birden fazla iş ilanı olabilir
    }
}
