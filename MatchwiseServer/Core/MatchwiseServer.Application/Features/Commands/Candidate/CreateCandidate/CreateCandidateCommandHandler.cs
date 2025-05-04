using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories.Candidate;
using MatchwiseServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Features.Commands.Candidate.CreateCandidate
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommandRequest, CreateCandidateCommandResponse>
    {
        private readonly ICandidateWriteRepository _candidateWriteRepository;
        private readonly IPasswordHasher<F.Candidate> _passwordHasher;

        public CreateCandidateCommandHandler(
            ICandidateWriteRepository candidateWriteRepository,
            IPasswordHasher<F.Candidate> passwordHasher)
        {
            _candidateWriteRepository = candidateWriteRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateCandidateCommandResponse> Handle(CreateCandidateCommandRequest request, CancellationToken cancellationToken)
        {
            var candidate = new F.Candidate
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                JobTitle = request.JobTitle,
                Email = request.Email
            };

            // Şifreyi hash’le
            candidate.Password = _passwordHasher.HashPassword(candidate, request.Password);

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
