using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Candidate.LoginCandidate
{
    public class LoginCandidateCommandRequest : IRequest<LoginCandidateCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
