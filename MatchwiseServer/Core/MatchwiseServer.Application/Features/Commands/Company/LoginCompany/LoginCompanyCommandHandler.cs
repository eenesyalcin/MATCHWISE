using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Company.LoginCompany
{
    public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommandRequest, LoginCompanyCommandResponse>
    {
        public async Task<LoginCompanyCommandResponse> Handle(LoginCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
