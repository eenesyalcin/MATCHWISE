using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class Interview : BaseEntity
    {
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        public Guid JobPostingId { get; set; }
        public JobPosting? JobPosting { get; set; }

        public DateTime InterviewDate { get; set; }                             // Mülakatın yapıldığı tarih
        public ICollection<InterviewResult>? InterviewResult { get; set; }      // Mülakat sonuçları
    }
}
