using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class JobPosting : BaseEntity
    {
        public string? Title { get; set; }                  // Pozisyon adı
        public Guid? CompanyId { get; set; }                // Foreign key
        public Company? Company { get; set; }                       
        public string? Description { get; set; }            // İş açıklaması
        public List<string>? RequiredSkills { get; set; }   // Gerekli yetenekler

        public ICollection<ProgrammingLanguage>? ProgrammingLanguage { get; set; }      // İş ilanı birden fazla programlama dili isteyebilir
        public ICollection<Interview>? Interview { get; set; }      // İş ilanı ile ilişkili mülakatlar
    }
}
