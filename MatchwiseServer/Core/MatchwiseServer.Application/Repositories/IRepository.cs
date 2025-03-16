using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace MatchwiseServer.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table {  get; }
    }
}
