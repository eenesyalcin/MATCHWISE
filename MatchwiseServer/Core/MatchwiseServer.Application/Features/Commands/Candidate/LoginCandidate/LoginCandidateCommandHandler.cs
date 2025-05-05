using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Abstractions.Token;
using MatchwiseServer.Application.DTOs;
using MatchwiseServer.Application.Exceptions;
using MatchwiseServer.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MatchwiseServer.Application.Features.Commands.Candidate.LoginCandidate
{
    public class LoginCandidateCommandHandler : IRequestHandler<LoginCandidateCommandRequest, LoginCandidateCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginCandidateCommandHandler(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginCandidateCommandResponse> Handle(LoginCandidateCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundUserException();
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded) // True dönerse Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginCandidateSuccessCommandResponse()
                {
                    Token = token,
                };
            }
            //return new LoginCandidateErrorCommandResponse()
            //{
            //    Message = "Kullanıcı adı veya şifre hatalı!"
            //};
            throw new AuthenticationErrorException();
        }
    }
}
