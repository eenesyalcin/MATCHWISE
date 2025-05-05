using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.DTOs;

namespace MatchwiseServer.Application.Features.Commands.Candidate.LoginCandidate
{
    public class LoginCandidateCommandResponse
    {
    }

    public class LoginCandidateSuccessCommandResponse : LoginCandidateCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginCandidateErrorCommandResponse : LoginCandidateCommandResponse
    {
        public string Message { get; set; }
    }
}
