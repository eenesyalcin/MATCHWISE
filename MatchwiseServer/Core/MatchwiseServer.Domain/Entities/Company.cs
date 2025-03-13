using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? Name { get; set; }        // Şirket adı
        public string? Industry { get; set; }    // Sektör
        public string? Location { get; set; }    // Konum-Adres

        public ICollection<JobPosting>? JobPosting { get; set; }   // Bir şirketin birden fazla iş ilanı olabilir
    }
}
