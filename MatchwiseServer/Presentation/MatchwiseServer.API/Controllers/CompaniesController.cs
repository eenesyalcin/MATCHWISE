using System.Net;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Application.ViewModels.Companies;
using MatchwiseServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        readonly private ICompanyReadRepository _companyReadRepository;
        readonly private ICompanyWriteRepository _companyWriteRepository;

        public CompaniesController(
            ICompanyReadRepository companyReadRepository,
            ICompanyWriteRepository companyWriteRepository)
        {
            _companyReadRepository = companyReadRepository;
            _companyWriteRepository = companyWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_companyReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _companyReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Company model)
        {
            await _companyWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Industry = model.Industry,
                Location = model.Location,
            });
            await _companyWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Company model)
        {
            Company company = await _companyReadRepository.GetByIdAsync(model.Id);
            company.Name = model.Name;
            company.Industry = model.Industry;
            company.Location = model.Location;
            await _companyWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _companyWriteRepository.RemoveAsync(id);
            await _companyWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
