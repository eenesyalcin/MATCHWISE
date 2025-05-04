using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Queries.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryResponse
    {
        public F.Company? Company { get; }

        public GetByIdCompanyQueryResponse(F.Company? company)
        {
            Company = company;
        }
    }
}
