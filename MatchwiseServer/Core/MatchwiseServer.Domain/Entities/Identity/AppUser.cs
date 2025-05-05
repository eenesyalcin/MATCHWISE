using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MatchwiseServer.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public Candidate? Candidate { get; set; }
        public Company? Company { get; set; }

    }
}
