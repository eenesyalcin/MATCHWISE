using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MediatR;

namespace MatchwiseServer.Application.Features.Commands.Company.RemoveCompany
{
    public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommandRequest, RemoveCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;

        public RemoveCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
        }

        public async Task<RemoveCompanyCommandResponse> Handle(RemoveCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            await _companyWriteRepository.RemoveAsync(request.Id);
            await _companyWriteRepository.SaveAsync();
            return new RemoveCompanyCommandResponse(true);
        }
    }
}
