using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchwiseServer.Application.Features.Commands.Candidate.CreateCandidate
{
    public class CreateCandidateCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
}
