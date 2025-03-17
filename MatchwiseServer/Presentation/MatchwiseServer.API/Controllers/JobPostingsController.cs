using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        readonly private IJobPostingWriteRepository _jobPostingWriteRepository;
        readonly private IJobPostingReadRepository _jobPostingReadRepository;

        public JobPostingsController(
            IJobPostingReadRepository jobPostingReadRepository,
            IJobPostingWriteRepository jobPostingWriteRepository)
        {
            _jobPostingReadRepository = jobPostingReadRepository;
            _jobPostingWriteRepository = jobPostingWriteRepository;
        }

        // 📌 Yeni iş ilanı ekleme metodu
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            await _jobPostingWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Full-Stack Developer",
                    CompanyId = Guid.Parse("a9f53597-abd5-4432-a246-49c4ee9cda8c"), // ✅ Sabit CompanyId atanıyor
                    Description = "Deneyimli bir Full-Stack Developer arıyoruz.",
                    RequiredSkills = new List<string> { "C#", ".NET", "React", "SQL" },
                    CreatedDate = DateTime.UtcNow
                }
            });

            await _jobPostingWriteRepository.SaveAsync();

            return Ok("✅ Yeni İş İlanı başarıyla eklendi!");
        }
    }
}
