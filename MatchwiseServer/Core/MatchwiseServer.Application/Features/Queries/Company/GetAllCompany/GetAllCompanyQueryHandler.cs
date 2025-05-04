using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MediatR;

namespace MatchwiseServer.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, GetAllCompanyQueryResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;

        public GetAllCompanyQueryHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            // Repository’den veriyi çek
            var companies = _companyReadRepository.GetAll(tracking: false);

            // Response'u oluşturup dön
            var response = new GetAllCompanyQueryResponse
            {
                Companies = companies
            };

            return Task.FromResult(response);
        }
    }
}
