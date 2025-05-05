using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities;
using MatchwiseServer.Domain.Entities.Common;
using MatchwiseServer.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatchwiseServer.Persistence.Contexts
{
    public class MatchwiseServerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MatchwiseServerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewResult> InterviewResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Company ↔ AppUser 1:1 ilişkisi
            builder.Entity<Company>()
                .HasOne(c => c.AppUser)
                .WithOne(u => u.Company)
                .HasForeignKey<Company>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Filterli unique index ekliyoruz:
            builder.Entity<Company>()
                .HasIndex(c => c.AppUserId)
                .IsUnique()
                .HasFilter("[AppUserId] IS NOT NULL");

            // Kandidat için de aynı filtreli index:
            builder.Entity<Candidate>()
                .HasIndex(c => c.AppUserId)
                .IsUnique()
                .HasFilter("[AppUserId] IS NOT NULL");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
