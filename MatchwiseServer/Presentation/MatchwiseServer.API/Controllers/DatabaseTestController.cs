using MatchwiseServer.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchwiseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseTestController : ControllerBase
    {
        private readonly MatchwiseServerDbContext _context;

        public DatabaseTestController(MatchwiseServerDbContext context)
        {
            _context = context;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                bool canConnect = _context.Database.CanConnect();
                if (canConnect)
                {
                    return Ok("✅ Veritabanına başarıyla bağlanıldı!");
                }
                else
                {
                    return BadRequest("❌ Veritabanına bağlanılamadı!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Bağlantı hatası: {ex.Message}");
            }
        }
    }
}
