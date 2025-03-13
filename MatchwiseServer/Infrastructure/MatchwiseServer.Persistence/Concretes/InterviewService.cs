using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Abstractions;
using MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Persistence.Concretes
{
    public class InterviewService : IInterviewService
    {
        public List<Interview> GetInterviews()
            => new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CandidateName = "Enes YALÇIN",
                    JobPosition = "Computer Enginner",
                    Status = "COMPLETED",
                    Questions = new List<string>
                    {
                        "OOP nedir?",
                        "Solid prensipleri nelerdir?",
                        "C# ile bir web API nasıl oluşturulur?",
                        "Entity Framework ile Code-First yaklaşımı nasıl çalışır?"
                    },
                    ChatMessages = new List<string>
                    {
                        "Merhaba, mülakata hoşgeldiniz.",
                        "Lütfen kendinizi tanıtın",
                        "İlk sorumuz geliyor: OOP nedir?",
                        "Teşekkürler! Bir sonraki soruya geçelim."
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CandidateName = "Sena Betül YAZICIOĞLU",
                    JobPosition = "Data Enginner",
                    Status = "COMPLETED",
                    Questions = new List<string>
                    {
                        "Data nedir?",
                        "Big data nedir?",
                        "TSQL Nedir?"
                    },
                    ChatMessages = new List<string>
                    {
                        "Merhaba, mülakata hoşgeldiniz.",
                        "Lütfen kendinizi tanıtın",
                        "İlk sorumuz geliyor: Data nedir?",
                        "Teşekkürler! Bir sonraki soruya geçelim."
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CandidateName = "Elif YALÇIN",
                    JobPosition = "Forest Enginner",
                    Status = "COMPLETED",
                    Questions = new List<string>
                    {
                        "Çam fidanları kaça ayrılır?",
                        "Bir ağacın yaşı nasıl hesaplanır?"
                    },
                    ChatMessages = new List<string>
                    {
                        "Merhaba, mülakata hoşgeldiniz.",
                        "Lütfen kendinizi tanıtın",
                        "İlk sorumuz geliyor: Çam fidanları kaça ayrılır?",
                        "Teşekkürler! Bir sonraki soruya geçelim."
                    }
                }
            }; 
    }
}
