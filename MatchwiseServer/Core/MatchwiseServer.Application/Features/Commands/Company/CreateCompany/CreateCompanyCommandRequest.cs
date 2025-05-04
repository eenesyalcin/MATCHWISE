using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
    {
        public string? CorporateName { get; set; }
        public string? TaxNumber { get; set; }
        public string? Sector { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
