using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryResponse
    {
        public IEnumerable<F.Company> Companies { get; set; }
    }
}
