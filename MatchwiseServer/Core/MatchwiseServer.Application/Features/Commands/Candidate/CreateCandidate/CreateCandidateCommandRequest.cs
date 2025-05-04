using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Candidate.CreateCandidate
{
    public class CreateCandidateCommandRequest : IRequest<CreateCandidateCommandResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? JobTitle { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
