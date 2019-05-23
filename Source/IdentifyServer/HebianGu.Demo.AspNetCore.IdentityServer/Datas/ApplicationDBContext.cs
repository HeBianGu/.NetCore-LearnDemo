using HebianGu.Demo.AspNetCore.IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HebianGu.Demo.AspNetCore.IdentityServer.Datas
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
    }
}
