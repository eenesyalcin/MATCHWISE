using MatchwiseServer.Application.Features.Commands.Candidate.CreateCandidate;
using MatchwiseServer.Application.Features.Commands.Candidate.LoginCandidate;
using MatchwiseServer.Application.Features.Commands.Company.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCandidateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCandidateCommandRequest loginCandidateCommandRequest)
        {
            LoginCandidateCommandResponse loginCandidateCommandResponse = await _mediator.Send(loginCandidateCommandRequest);
            return Ok(loginCandidateCommandResponse);
        }
    }
}
