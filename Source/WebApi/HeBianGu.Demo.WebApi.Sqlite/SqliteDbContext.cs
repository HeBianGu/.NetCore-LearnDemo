using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Sqlite
{
    public class SqliteDbContext : DbContext
    {
        public virtual DbSet<CustomEntity> CustomEntity { get; set; } 

        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {

        }
    }
}
