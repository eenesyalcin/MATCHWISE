using System.Net;
using Azure.Core;
using MatchwiseServer.Application.Features.Commands.Company.CreateCompany;
using MatchwiseServer.Application.Features.Commands.Company.UpdateCompany;
using MatchwiseServer.Application.Features.Queries.Company.GetAllCompany;
using MatchwiseServer.Application.Features.Queries.Company.GetByIdCompany;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Application.ViewModels.Companies;
using MatchwiseServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        readonly private ICompanyReadRepository _companyReadRepository;
        readonly private ICompanyWriteRepository _companyWriteRepository;
        readonly IMediator _mediator;

        public CompaniesController(
            ICompanyReadRepository companyReadRepository,
            ICompanyWriteRepository companyWriteRepository,
            IMediator mediator)
        {
            _companyReadRepository = companyReadRepository;
            _companyWriteRepository = companyWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCompanyQueryResponse response = await _mediator.Send(new GetAllCompanyQueryRequest());
            return Ok(response.Companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _mediator.Send(new GetByIdCompanyQueryRequest(id));
            if (response.Company is null)
                return NotFound();
            return Ok(response.Company);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response.Message);

            // CompanyId olmadığı için sadece response dönüyoruz
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCompanyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return NotFound();    // ID bulunamadıysa 404

            return NoContent();       // 204: güncelleme başarılı
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _companyWriteRepository.RemoveAsync(id);
            await _companyWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
