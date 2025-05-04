using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryRequest : IRequest<GetAllCompanyQueryResponse>
    {
    }
}
