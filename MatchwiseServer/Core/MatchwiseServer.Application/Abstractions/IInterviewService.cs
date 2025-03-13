using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities;

namespace MatchwiseServer.Application.Abstractions
{
    public interface IInterviewService
    {
        List<Interview> GetInterviews();
    }
}
