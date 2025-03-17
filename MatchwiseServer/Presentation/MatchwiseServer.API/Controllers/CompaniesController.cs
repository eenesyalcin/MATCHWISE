using MatchwiseServer.Application.Repositories;
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

        // 📌 Tracking mekanizmasının test edilmesi
        [HttpPut]
        public async Task<IActionResult> Get()
        {
            Company? company = await _companyReadRepository.GetByIdAsync("2d847589-f8d1-4ffa-b068-2d001632b899", false);

            if (company == null)
            {
                return NotFound("❌ Hata: Belirtilen ID'ye sahip şirket bulunamadı!");
            }

            company.Location = "Antalya, Türkiye";
            await _companyWriteRepository.SaveAsync();

            return Ok("✅ Şirket bilgisi güncellendi!");
        }

    }
}
