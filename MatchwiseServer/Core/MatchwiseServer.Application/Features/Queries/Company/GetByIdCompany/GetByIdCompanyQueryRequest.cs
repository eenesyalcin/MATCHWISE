using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MatchwiseServer.Application.Features.Queries.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryRequest : IRequest<GetByIdCompanyQueryResponse>
    {
        public string Id { get; }

        public GetByIdCompanyQueryRequest(string id)
        {
            Id = id;
        }
    }
}
