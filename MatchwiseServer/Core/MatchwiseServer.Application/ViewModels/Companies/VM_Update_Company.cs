using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchwiseServer.Application.ViewModels.Companies
{
    public class VM_Update_Company
    {
        public string? Id { get; set; }
        public string? CorporateName { get; set; }
        public string? TaxNumber { get; set; }
        public string? Sector { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
