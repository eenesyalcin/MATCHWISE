using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Repositories.Candidate;
using MatchwiseServer.Persistence.Contexts;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Persistence.Repositories.Candidate
{
    public class CandidateWriteRepository : WriteRepository<F.Candidate>, ICandidateWriteRepository
    {
        public CandidateWriteRepository(MatchwiseServerDbContext context) : base(context)
        {
        }
    }
}
