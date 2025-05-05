using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Candidate.LoginCandidate
{
    public class LoginCandidateCommandHandler : IRequestHandler<LoginCandidateCommandRequest, LoginCandidateCommandResponse>
    {
        public async Task<LoginCandidateCommandResponse> Handle(LoginCandidateCommandRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
