using MatchwiseServer.Domain.Entities.Common;
using MatchwiseServer.Domain.Entities.Identity;

namespace MatchwiseServer.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? JobTitle { get; set; }   // Meslek

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<ProgrammingLanguage>? ProgrammingLanguage { get; set; }
        public ICollection<Interview>? Interview { get; set; }  // Adayın yaptığı mülakatlar
    }
}
