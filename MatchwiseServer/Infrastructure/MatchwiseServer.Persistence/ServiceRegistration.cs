using MatchwiseServer.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchwiseServer.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = Environment.GetEnvironmentVariable("MATCHWISE_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("❌ Connection string bulunamadı. Lütfen environment değişkenini kontrol et.");
                throw new InvalidOperationException("Connection string eksik!");
            }

            Console.WriteLine($"✅ Kullanılan Connection String: {connectionString}");

            services.AddDbContext<MatchwiseServerDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }
}
