using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Oracle
{
    public class OracleDbContext : DbContext
    {
        public virtual DbSet<CustomEntity> CustomEntity { get; set; } 

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
    }
}
