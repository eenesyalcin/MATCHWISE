using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MatchwiseServer.Application.Features.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;
        private readonly IPasswordHasher<Company> _passwordHasher;

        public CreateCompanyCommandHandler(
            ICompanyWriteRepository companyWriteRepository,
            IPasswordHasher<Company> passwordHasher)
        {
            _companyWriteRepository = companyWriteRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Id = Guid.NewGuid(),
                CorporateName = request.CorporateName,
                TaxNumber = request.TaxNumber,
                Sector = request.Sector,
                Location = request.Location,
                Email = request.Email
            };
            company.Password = _passwordHasher.HashPassword(company, request.Password);

            await _companyWriteRepository.AddAsync(company);
            await _companyWriteRepository.SaveAsync();

            return new CreateCompanyCommandResponse
            {
                Success = true,
                Message = "Şirket başarıyla oluşturuldu."
            };
        }
    }
}
