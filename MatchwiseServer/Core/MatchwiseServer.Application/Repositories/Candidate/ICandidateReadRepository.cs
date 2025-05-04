using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Repositories.Candidate
{
    public interface ICandidateReadRepository : IReadRepository<F.Candidate>
    {
    }
}
