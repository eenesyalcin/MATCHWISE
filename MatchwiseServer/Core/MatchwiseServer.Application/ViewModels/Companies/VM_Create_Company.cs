using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchwiseServer.Application.ViewModels.Companies
{
    public class VM_Create_Company
    {
        public string? Name { get; set; }        // Şirket adı
        public string? Industry { get; set; }    // Sektör
        public string? Location { get; set; }    // Konum-Adres
    }
}
