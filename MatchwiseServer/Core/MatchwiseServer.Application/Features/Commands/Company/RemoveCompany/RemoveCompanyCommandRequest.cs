using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Company.RemoveCompany
{
    public class RemoveCompanyCommandRequest : IRequest<RemoveCompanyCommandResponse>
    {
        public string Id { get; set; } = default!;

        public RemoveCompanyCommandRequest() { }
        public RemoveCompanyCommandRequest(string id) => Id = id;
    }
}
