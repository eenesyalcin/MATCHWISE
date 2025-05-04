using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;

namespace MatchwiseServer.Application.Features.Commands.Company.UpdateCompany
{
    public class UpdateCompanyCommandResponse
    {
        public bool Success { get; }

        public UpdateCompanyCommandResponse(bool success)
        {
            Success = success;
        }
    }
}
