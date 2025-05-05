using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.DTOs;

namespace MatchwiseServer.Application.Features.Commands.Company.LoginCompany
{
    public class LoginCompanyCommandResponse
    {
    }

    public class LoginComapanySuccessCommandResponse : LoginCompanyCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginComapanyErrorCommandResponse : LoginCompanyCommandResponse
    {
        public string Message { get; set; }
    }
}
