using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchwiseServer.Persistence.Contexts
{
    public class MatchwiseServerDbContext : DbContext
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
        public DbSet<Test> Tests { get; set; }
    }
}
