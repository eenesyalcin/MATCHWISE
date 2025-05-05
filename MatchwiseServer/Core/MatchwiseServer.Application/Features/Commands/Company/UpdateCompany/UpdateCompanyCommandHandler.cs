using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Commands.Company.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly ICompanyWriteRepository _companyWriteRepository;
        private readonly UserManager<AppUser> _userManager;

        public UpdateCompanyCommandHandler(
            ICompanyReadRepository companyReadRepository,
            ICompanyWriteRepository companyWriteRepository,
            UserManager<AppUser> userManager)
        {
            _companyReadRepository = companyReadRepository;
            _companyWriteRepository = companyWriteRepository;
            _userManager = userManager;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            // 1) Var olan Company’yi DB’den çek (tracking: true, çünkü güncelleyeceğiz)
            var company = await _companyReadRepository.GetByIdAsync(request.Id!, tracking: true);
            if (company is null)
                return new UpdateCompanyCommandResponse(false);

            // 2) Identity User’ı çek
            var user = await _userManager.FindByIdAsync(company.AppUserId);
            if (user is null)
                return new UpdateCompanyCommandResponse(false);

            // 3) E-posta güncellemesi (eğer değiştiyse)
            if (!string.Equals(user.Email, request.Email, StringComparison.OrdinalIgnoreCase))
            {
                user.Email = request.Email;
                user.UserName = request.Email;  // userName olarak email kullanıyorsanız
                var emailResult = await _userManager.UpdateAsync(user);
                if (!emailResult.Succeeded)
                {
                    var errs = string.Join("; ", emailResult.Errors.Select(e => e.Description));
                    return new UpdateCompanyCommandResponse(false);
                }
            }

            // 4) Şifre güncellemesi (eğer yeni şifre verildiyse)
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                // Parola sıfırlama token’ı üretip reset işlemini yapıyoruz
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var pwdResult = await _userManager.ResetPasswordAsync(user, token, request.Password);
                if (!pwdResult.Succeeded)
                {
                    var errs = string.Join("; ", pwdResult.Errors.Select(e => e.Description));
                    return new UpdateCompanyCommandResponse(false);
                }
            }

            // 3) Diğer alanları güncelle
            company.CorporateName = request.CorporateName;
            company.TaxNumber = request.TaxNumber;
            company.Sector = request.Sector;
            company.Location = request.Location;

            // 4) Değişiklikleri kaydet
            await _companyWriteRepository.SaveAsync();

            return new UpdateCompanyCommandResponse(true);
        }
    }
}
