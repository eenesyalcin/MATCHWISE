using MatchwiseServer.Domain.Entities;
using MatchwiseServer.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MatchwiseServerDbContext _context;

        public TestController(MatchwiseServerDbContext context)
        {
            _context = context;
        }

        // ✅ Yeni veri ekleme
        [HttpPost]
        public IActionResult AddTestEntity([FromBody] Test testEntity)
        {
            _context.Tests.Add(testEntity);
            _context.SaveChanges();
            return Ok("✅ Yeni kayıt eklendi!");
        }

        // ✅ Tüm verileri çekme
        [HttpGet]
        public IActionResult GetAllTestEntities()
        {
            var data = _context.Tests.ToList();
            return Ok(data);
        }
    }
}
