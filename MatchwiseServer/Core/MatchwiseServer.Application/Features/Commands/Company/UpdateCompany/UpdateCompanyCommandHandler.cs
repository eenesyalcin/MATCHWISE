using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Commands.Company.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly ICompanyWriteRepository _companyWriteRepository;

        public UpdateCompanyCommandHandler(
            ICompanyReadRepository companyReadRepository,
            ICompanyWriteRepository companyWriteRepository)
        {
            _companyReadRepository = companyReadRepository;
            _companyWriteRepository = companyWriteRepository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            // 1) Var olan Company’yi DB’den çek (tracking: true, çünkü güncelleyeceğiz)
            var company = await _companyReadRepository.GetByIdAsync(request.Id!, tracking: true);
            if (company is null)
                return new UpdateCompanyCommandResponse(false);

            // 2) Şifreyi hash’le
            var hasher = new PasswordHasher<F.Company>();
            company.Password = hasher.HashPassword(company, request.Password!);

            // 3) Diğer alanları güncelle
            company.CorporateName = request.CorporateName;
            company.TaxNumber = request.TaxNumber;
            company.Sector = request.Sector;
            company.Location = request.Location;
            company.Email = request.Email;

            // 4) Değişiklikleri kaydet
            await _companyWriteRepository.SaveAsync();

            return new UpdateCompanyCommandResponse(true);
        }
    }
}
