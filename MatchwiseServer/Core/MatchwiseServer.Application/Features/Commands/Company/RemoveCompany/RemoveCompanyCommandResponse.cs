using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchwiseServer.Application.Features.Commands.Company.RemoveCompany
{
    public class RemoveCompanyCommandResponse
    {
        public bool Success { get; }

        public RemoveCompanyCommandResponse(bool success)
        {
            Success = success;
        }
    }
}
