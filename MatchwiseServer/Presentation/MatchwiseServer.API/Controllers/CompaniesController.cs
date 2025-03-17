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

        // 📌 Interceptor operasyonunda CreatedDate property'sinin test edilmesi.
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            await _companyWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Teknoloji A.Ş.",
                    Industry = "Yazılım ve Bilişim",
                    Location = "Trabzon, Türkiye"
                }
            });

            await _companyWriteRepository.SaveAsync();

            return Ok("✅ Yeni Şirket başarıyla eklendi!");
        }

        // 📌 Interceptor operasyonunda UpdatedDate property'sinin test edilmesi.
        [HttpPut]
        public async Task Update()
        {
            Company company = await _companyReadRepository.GetByIdAsync("d98cccdf-095b-46db-be9f-46be12152136");
            company.Location = "Ankara, Türkiye";
            await _companyWriteRepository.SaveAsync();
        }
    }
}
