using MatchwiseServer.Domain.Entities.Common;

namespace MatchwiseServer.Domain.Entities
{
    public class InterviewResult : BaseEntity
    {
        public Guid InterviewId { get; set; }
        public Interview? Interview { get; set; }

        public string? Question { get; set; }           // GPT'nin sorduğu soru
        public string? CandidateAnswer { get; set; }    // Adayın cevabı
        public int Score { get; set; }                  // Adayın cevabına GPT'nin verdiği puan
    }
}
