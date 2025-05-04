using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Queries.GetAllCompany
{
    public class GetAllCompanyQueryResponse
    {
        public IEnumerable<Company> Companies { get; set; }
    }
}
