using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories;
using MatchwiseServer.Domain.Entities;
using MatchwiseServer.Persistence.Contexts;

namespace MatchwiseServer.Persistence.Repositories
{
    public class JobPostingWriteRepository : WriteRepository<JobPosting>, IJobPostingWriteRepository
    {
        public JobPostingWriteRepository(MatchwiseServerDbContext context) : base(context)
        {
        }
    }
}
