using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewReadRepository _interviewReadRepository;
        private readonly IInterviewWriteRepository _interviewWriteRepository;

        public InterviewsController(
            IInterviewReadRepository interviewReadRepository,
            IInterviewWriteRepository interviewWriteRepository)
        {
            _interviewReadRepository = interviewReadRepository;
            _interviewWriteRepository = interviewWriteRepository;
        }

        // 📌 Yeni mülakat ekleme metodu
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            await _interviewWriteRepository.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    JobPostingId = Guid.Parse("6560d1d7-4450-4ac0-ac6e-8de54f35330a"), // ✅ Sabit JobPostingId atanıyor
                    InterviewDate = DateTime.UtcNow
                }
            });

            await _interviewWriteRepository.SaveAsync();

            return Ok("✅ Yeni Mülakat başarıyla eklendi!");
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            Interview? interview = await _interviewReadRepository.GetByIdAsync(id);
            return Ok(interview);
        }
    }
}
