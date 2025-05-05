using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Application.Repositories.Candidate;
using MatchwiseServer.Domain.Entities.Identity;
using MatchwiseServer.Persistence.Contexts;
using MatchwiseServer.Persistence.Repositories;
using MatchwiseServer.Persistence.Repositories.Candidate;
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

            services.AddDbContext<MatchwiseServerDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MatchwiseServerDbContext>();

            services.AddScoped<IInterviewReadRepository, InterviewReadRepository>();
            services.AddScoped<IInterviewWriteRepository, InterviewWriteRepository>();
            services.AddScoped<IJobPostingReadRepository, JobPostingReadRepository>();
            services.AddScoped<IJobPostingWriteRepository, JobPostingWriteRepository>();
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<ICandidateReadRepository, CandidateReadRepository>();
            services.AddScoped<ICandidateWriteRepository, CandidateWriteRepository>();
        }

    }
}
