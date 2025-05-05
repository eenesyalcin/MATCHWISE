using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities;
using MatchwiseServer.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;
        private readonly UserManager<AppUser> _userManager;

        public CreateCompanyCommandHandler(
            ICompanyWriteRepository companyWriteRepository,
            UserManager<AppUser> userManager)
        {
            _companyWriteRepository = companyWriteRepository;
            _userManager = userManager;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email
            };
            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (!identityResult.Succeeded)
            {
                // Oluşan hata mesajlarını birleştirip dönebilirsiniz
                var errors = string.Join("; ", identityResult.Errors.Select(e => e.Description));
                return new CreateCompanyCommandResponse
                {
                    Success = false,
                    Message = errors
                };
            }

            var company = new F.Company
            {
                Id = Guid.NewGuid(),
                CorporateName = request.CorporateName,
                TaxNumber = request.TaxNumber,
                Sector = request.Sector,
                Location = request.Location,
                AppUserId = user.Id
            };

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
