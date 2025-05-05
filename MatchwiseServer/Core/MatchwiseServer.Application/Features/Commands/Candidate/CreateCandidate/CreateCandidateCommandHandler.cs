using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories.Candidate;
using MatchwiseServer.Domain.Entities;
using MatchwiseServer.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Commands.Candidate.CreateCandidate
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommandRequest, CreateCandidateCommandResponse>
    {
        private readonly ICandidateWriteRepository _candidateWriteRepository;
        private readonly UserManager<AppUser> _userManager;

        public CreateCandidateCommandHandler(
            ICandidateWriteRepository candidateWriteRepository,
            UserManager<AppUser> userManager)
        {
            _candidateWriteRepository = candidateWriteRepository;
            _userManager = userManager;
        }

        public async Task<CreateCandidateCommandResponse> Handle(CreateCandidateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (!identityResult.Succeeded)
            {
                // Hata mesajlarını birleştirip dönüyoruz
                var errors = string.Join("; ", identityResult.Errors.Select(e => e.Description));
                return new CreateCandidateCommandResponse
                {
                    Success = false,
                    Message = errors
                };
            }

            var candidate = new F.Candidate
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                JobTitle = request.JobTitle,
                AppUserId = user.Id
            };

            // Veritabanına ekle
            await _candidateWriteRepository.AddAsync(candidate);
            await _candidateWriteRepository.SaveAsync();

            return new CreateCandidateCommandResponse
            {
                Success = true,
                Message = "Aday başarıyla oluşturuldu."
            };
        }
    }
}
