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

        // 📌 Yeni şirket ekleme metodu
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            await _companyWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Teknoloji A.Ş.",
                    Industry = "Yazılım ve Bilişim",
                    Location = "Ankara, Türkiye",
                    CreatedDate = DateTime.UtcNow
                }
            });

            await _companyWriteRepository.SaveAsync();

            return Ok("✅ Yeni Şirket başarıyla eklendi!");
        }
    }
}
