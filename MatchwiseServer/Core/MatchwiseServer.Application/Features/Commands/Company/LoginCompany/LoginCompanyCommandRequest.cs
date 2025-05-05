using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Company.LoginCompany
{
    public class LoginCompanyCommandRequest : IRequest<LoginCompanyCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
