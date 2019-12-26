using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Mysql
{
    public class MysqlDbContext : DbContext
    {
        public virtual DbSet<CustomEntity> CustomEntity { get; set; } 

        public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
        {

        }
    }
}
