using System.Net;
using MatchwiseServer.Application.Features.Queries.GetAllCompany;
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
            return Ok(await _companyReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Company model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Şifreyi hash'le
            var passwordHasher = new PasswordHasher<Company>();
            string hashedPassword = passwordHasher.HashPassword(null, model.Password);

            await _companyWriteRepository.AddAsync(new()
            {
                CorporateName = model.CorporateName,
                TaxNumber = model.TaxNumber,
                Sector = model.Sector,
                Location = model.Location,
                Email = model.Email,
                Password = hashedPassword
            });
            await _companyWriteRepository.SaveAsync();
            //return StatusCode((int)HttpStatusCode.Created);
            return Ok(new { message = "Validasyon Başarılı" });
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Company model)
        {
            Company company = await _companyReadRepository.GetByIdAsync(model.Id);

            // Şifreyi hash'le
            var passwordHasher = new PasswordHasher<Company>();
            company.Password = passwordHasher.HashPassword(company, model.Password);

            company.CorporateName = model.CorporateName;
            company.TaxNumber = model.TaxNumber;
            company.Sector = model.Sector;
            company.Location = model.Location;
            company.Email = model.Email;

            await _companyWriteRepository.SaveAsync();

            return Ok();
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
