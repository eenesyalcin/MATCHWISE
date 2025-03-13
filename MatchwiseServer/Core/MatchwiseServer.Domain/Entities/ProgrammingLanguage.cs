using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class ProgrammingLanguage : BaseEntity
    {
        public string? Name { get; set; }   // Programlama dilinin adı

        public ICollection<Candidate>? Candidate { get; set; }
    }
}
